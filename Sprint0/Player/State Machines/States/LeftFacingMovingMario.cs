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
    public class LeftFacingMovingMario : IMarioState
    {
        public string ID { get; } = "LeftMovingMario";
        private Vector2 velocity = new Vector2(GameUtilities.VairY, 0);

        private Mario mario;

        public LeftFacingMovingMario(Mario marioRef)
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
            mario.currentState = new LeftFacingJumpingMario(mario, new Vector2(-7f, -10), 0, true);
            mario.OnStateChange();
        }
        public void StopJump()
        {

        }

        public void MoveLeft()
        {
            //No op
        }

        public void MoveRight()
        {
            mario.currentState = new RightFacingMovingMario(mario);
            mario.OnStateChange();
        }

        public void StopMovingHorizontal()
        {
            mario.currentState = new LeftFacingStaticMario(mario);
            mario.OnStateChange();
        }
        public void StopMovingVertical()
        {
            // no op
        }
        public void UpBounce(Rectangle rectangle)
        {

            if (!mario.GetGrounded() && rectangle.Width>-velocity.X)
            {
                mario.SetGrounded(true);
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y - rectangle.Height);
                //Debug.WriteLine("Nudge Moving up: " + rectangle.Height);
                StopMovingVertical();
            }
        }
        public void DownBounce(Rectangle rectangle)
        {
            if(rectangle.Width > -velocity.X)
            {
                mario.Position = new Vector2(mario.Position.X, mario.Position.Y + rectangle.Height);
            }
              
           
            
            //velocity = new Vector2(velocity.X, 2f);
        }
        public void RightBounce(Rectangle rectangle)
        {
            mario.Position = new Vector2(mario.Position.X + rectangle.Width, mario.Position.Y);
            //StopMovingHorizontal();
        }
        public void LeftBounce(Rectangle rectangle)
        {
            Debug.WriteLine("Collision Rectangle:"+rectangle);
            mario.Position = new Vector2(mario.Position.X - rectangle.Width, mario.Position.Y);
            StopMovingHorizontal();
        }
        public void Update()
        {
            if (mario.GetGrounded())
            {
                velocity = new Vector2(-GameUtilities.VairX, 0f);
            }
            else
            {
                velocity = new Vector2(-GameUtilities.VairX, GameUtilities.gravity);
            }
            mario.MoveSprite(velocity);
        }

        public void MarioBounce(Rectangle rectangle)
        {
            velocity.Y = -12f;
        }
    }
}
