namespace Testing.Dnn.ArmyManager.ArmyManager.ViewArmyManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Overall data structure Army- has a collection of Units, a Name, and a Max points value
    /// </summary>
    public class Army
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Army"/> class.
        /// Creates a new army with a single unit
        /// </summary>
        public Army()
        {
            this.ArmyName = "Default Army Name";

            this.MaxPoints = 2000;
            Unit initialUnit = new Termagant();
            var newUnits = new List<Unit> { initialUnit };

            this.Units = newUnits;
        }

        private string ArmyName { get; set; }

        private int MaxPoints { get; set; }

        private IEnumerable<Unit> Units { get; set; }
    }
}