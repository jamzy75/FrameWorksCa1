using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorksCA1
{
    internal class Horse
    {
        public string horseID;


        public string horseName;

        public DateTime dateOfBirth;



        public string HorseID
        {
            get { return horseID; }
            set { horseID = value; }

        }

        public string HorseName
        {
            get { return horseName; }
            set { horseName = value; }

        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        // No-argument constructor
        public Horse()
        {
        }

        // Full constructor
        public Horse(string horseID, string horseName, DateTime dateOfBirth)
        {
            this.horseID = horseID;
            this.horseName = horseName;
            this.dateOfBirth = dateOfBirth;
        }


        public override string ToString()
        {
            return $"HorseID: {horseID}, HorseName: {horseName}, DateOfBirth: {dateOfBirth}";
        }

    }


}