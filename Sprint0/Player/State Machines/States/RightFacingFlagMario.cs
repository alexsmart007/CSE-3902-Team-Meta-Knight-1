﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
    class RightFacingFlagMario : IMarioState
    {
        private Mario mario;
        public string ID { get; } = "RightClimbMario";
        private Vector2 velocity = new Vector2(0, 0);
       

        public RightFacingFlagMario(Mario marioRef)
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
            mario.soundInfo.PlaySound("smb2_jump", false);
            mario.currentState = new RightFacingJumpingMario(mario, new Vector2(velocity.X, -10), 0, true);
            mario.OnStateChange();
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
            velocity.Y = 0;
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
            //When mario hits the floor turn, he should visually spin around the flag pole
            if (mario.GetGrounded())
            {
                velocity = new Vector2(0f, 0f);
                mario.Position = new Vector2(mario.Position.X + GameUtilities.bias, mario.Position.Y);
                mario.currentState = new LeftFacingFlagMario(mario);
                mario.OnStateChange();

            }
            else 
            {
                //Otherwise he keeps sliding down
                velocity = new Vector2(0, GameUtilities.gravity);
            }
            
            mario.MoveSprite(velocity);
        }

        public void MarioBounce(Rectangle rectangle)
        {
            velocity.Y = -12f;
        }
    }
}