﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
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
        private const float moveVelocity = 2f;

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
            mario.currentState = new LeftFacingJumpingMario(mario, new Vector2(-2, -5), 15, true);
            mario.OnStateChange();
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
        public void Bounce(string direction)
        {
            switch (direction)
            {
                case "up":
                    break;
                case "down":
                    //RESET VELOCITY, BLOCK UNDER
                    break;
                case "left":
                    mario.currentState = new LeftFacingStaticMario(mario);
                    mario.OnStateChange();
                    break;
                case "right":
                    break;
                default:
                    break;
            }
        }
        public void Update()
        {
            /*
             * Try to apply downwards velocity? Walking off an edge should make the player fall.
             *  If theyre on ground their velocity should be stopped by command to bounce from bottom.
             */
            mario.MoveSprite(new Vector2(-1 * moveVelocity, 0f));
        }
    }
}
