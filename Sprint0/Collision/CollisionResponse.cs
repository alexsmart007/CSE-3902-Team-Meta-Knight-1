﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Sprint0
{
    /*
     * Uses 2 dictionaries to return 
     */

    public class CollisionResponse
    {
        //<objName +  direction, commandName>
        public Dictionary<String, String> MoverResponse;
        public Dictionary<String, String> TargetResponse;
        private static CollisionResponse instance;
        public static CollisionResponse Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new CollisionResponse();

                }
                return instance;
            }
        }
        public CollisionResponse()
        {
            MoverResponse = new Dictionary<String, String>();
            TargetResponse = new Dictionary<String, String>();

            XmlReader reader = XmlReader.Create(Path.GetFullPath("Collision\\CollisionData.xml"));

            while (reader.ReadToFollowing("row"))
            {
                ConstructDictionary(reader.ReadSubtree());
            }
            reader.Close(); // Closes the reader for the XML document

        }
        public void ConstructDictionary(XmlReader reader)
        {
            while (reader.ReadToFollowing("obj"))
            {
                Console.Write("Building Dictionary");
                //get strings
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');

                //convert strings to ints
                String obj1 = objValues[0];
                String obj2 = objValues[1];
                String direction = objValues[2];
                String commandName1 = objValues[3];
                String commandName2 = objValues[4];

                //object mover = cInfoM.Invoke(new object[] )
                MoverResponse.Add(obj1+direction, commandName1);
                TargetResponse.Add(obj2+direction, commandName2);
            }
            reader.Close(); // Closes the local reader for the object
        }

        public void CollisionOccurrence(IGameObject collider, IGameObject collided, String direction)
        {

            String commandName1 = MoverResponse[collider.ToString() + direction];
            String commandName2 = TargetResponse[collided.ToString() + direction];


            Type t1 = Type.GetType(commandName1);
            Type[] types1 = { Type.GetType(collider.ToString()) };
            object[] param1 = { collider };

            ConstructorInfo constructorInfoObj1 = t1.GetConstructor(types1);

            ICommand command1 = (ICommand)constructorInfoObj1.Invoke(param1);

            command1.Execute();


            Type t2 = Type.GetType(commandName2);
            Type[] types2 = { Type.GetType(collided.ToString()) };
            object[] param2 = { collided };

            ConstructorInfo constructorInfoObj2 = t2.GetConstructor(types2);

            ICommand command2 = (ICommand)constructorInfoObj2.Invoke(param2);

            command2.Execute();

        }
    }
}
