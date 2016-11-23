// <copyright file="GetArmyManagerRequest.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager.API
{
    /// <summary>Request object for <see cref="ArmyManagerController.GetArmyManager" /></summary>
    public class GetArmyManagerRequest
    {
        /// <summary>Initializes a new instance of the <see cref="GetArmyManagerRequest"/> class.</summary>
        /// <param name="item1">The item1.</param>
        public GetArmyManagerRequest(string item1)
        {
            this.Item1 = item1;
        }

        /// <summary>Gets or sets the item1.</summary>
        /// <value>The item1.</value>
        public string Item1 { get; set; }
    }
}
