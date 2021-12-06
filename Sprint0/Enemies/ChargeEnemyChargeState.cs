﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Timers;
using Sprint0.UtilityClasses;

namespace Sprint0.Enemies
{
    class ChargeEnemyChargeState : IEnemyState
    {
        private string ID = "ChargeEnemyChargeState";
        private Timer chargeTimer;
        private bool grounded;
        private IEnemy enemy;
        private string direction;

        public ChargeEnemyChargeState(IEnemy enemyRef, string directionRef)
        {
            Debug.WriteLine("CHARGE STATE");

            enemy = enemyRef;
            chargeTimer = new Timer(GameUtilities.chargeEnemyChargeTime, FinishCharging);
            direction = directionRef;
        }

        public void BigUpBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void DownBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y + rectangle.Height);
        }

        public bool GetGrounded()
        {
            return grounded;
        }

        public void GetKicked(Rectangle rec)
        {
            throw new NotImplementedException();
        }

        public string GetStateID()
        {
            throw new NotImplementedException();
        }

        public Vector2 GetVelocity()
        {
            throw new NotImplementedException();
        }

        public void LeftBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void RightBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void SetGrounded(bool grounded)
        {
            throw new NotImplementedException();
        }

        public void SetXVelocity(float x)
        {
            throw new NotImplementedException();
        }

        public void SetYVelocity(float y)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage()
        {
           
        }

        public void UpBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        private void FinishCharging()
        {
            enemy.CurrentState = new ChargeEnemyAttackState(enemy, direction);
        }

        public void Update()
        {
            
        }
    }
}
