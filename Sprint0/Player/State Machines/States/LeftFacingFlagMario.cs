﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Sprint0.UtilityClasses;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0
{
    public class LeftFacingFlagMario : IMarioState
    {
        private Mario mario;
        public string ID { get; } = "LeftClimbMario";
        private Vector2 velocity = new Vector2(0, 0);
        int currentTurnTime = 0;

        public LeftFacingFlagMario(Mario marioRef)
        {
            mario = marioRef;
        }
        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void Crouch()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {
            //Flag Mario cannot jump
        }
        public void StopJump()
        {

        }
        public void MoveLeft()
        {
            mario.currentState = new LeftFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void MoveRight()
        {
            mario.currentState = new RightFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void StopMovingHorizontal()
        {
            velocity.X = 0;
        }
        public void StopMovingVertical()
        {
            velocity.Y=0;
        }
        public void UpBounce(Rectangle rectangle)
        {
            mario.SetGrounded(true);
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - rectangle.Height);
            //Debug.WriteLine("Nudge Static up: " + rectangle.Height);
            StopMovingVertical();
        }
        public void DownBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + rectangle.Height);
            velocity = new Vector2(velocity.X, 2f);
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + rectangle.Width, mario.Position.Y);
            //StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X - rectangle.Width, mario.Position.Y);
            //StopMovingHorizontal();
        }
        public void Update()
        {
            if (mario.GetGrounded())
            {
                velocity = new Vector2(0f, 0f);
                currentTurnTime++;
                //Giving mario some time in this state so it is visible to the player
                if (currentTurnTime >= GameUtilities.maxTimeFlagTurn)
                {
                    mario.currentState = new RightFacingMovingMario(mario);
                    mario.OnStateChange();
                }
               

            }
            else
            {
                velocity = new Vector2(0f, GameUtilities.gravity);
            }
         mario.MoveSprite(velocity);
        }

        public void MarioBounce(Rectangle rectangle)
        {
            velocity.Y = -10f;
        }
    }
}
