// model classes for BMI calculator
// GC

using System;
using System.ComponentModel.DataAnnotations;

namespace BMICalculator
{
    public enum BMICategory { Underweight, Normal, Overweight, Obese };

    public class BMI
    {
        const double UnderWeightUpperLimit = 18.4;              // inclusive upper limit
        const double NormalWeightUpperLimit = 24.9;
        const double OverWeightUpperLimit = 29.9;               // Obese from 30 +

        // conversion factors from imperial to metr

        const double PoundsToKgs = 0.453592;
        const double InchestoMetres = 0.0254;

        [Display(Name = "Weight - Stones")]
        [Range(5, 50, ErrorMessage = "Stones must be between 5 and 50")]                              // max 50 stone
        public int WeightStones { get; set; }

        [Display(Name = "Pounds")]
        [Range(0, 13, ErrorMessage = "Pounds must be between 0 and 13")]                              // 14 lbs in a stone
        public int WeightPounds { get; set; }

        [Display(Name = "Height - Feet")]
        [Range(4, 7, ErrorMessage = "Feet must be between 4 and 7")]                               // max 7 feet
        public int HeightFeet { get; set; }

        [Display(Name = "Inches")]
        [Range(0, 11, ErrorMessage = "Inches must be between 0 and 11")]                              // 12 inches in a foot
        public int HeightInches { get; set; }

        public BMI()
        {
            WeightStones = 0;
            WeightPounds = 0;
            HeightFeet = 0;
            HeightInches = 0;
        }

        public BMI(int sin, int pin, int fin, int iin)
        {
            WeightStones = sin;
            WeightPounds = pin;
            HeightFeet = fin;
            HeightInches = iin;
        }

        // calculate BMI, display to 2 decimal places
        [Display(Name = "Your BMI is")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BMIValue
        {
            get
            {
                // bmi = weight in Kgs / height in metres squared

                double totalWeightInPounds = (WeightStones * 14) + WeightPounds;
                double totalHeightInInches = (HeightFeet * 12) + HeightInches;

                // do conversions to metric
                double totalWeightInKgs = totalWeightInPounds * PoundsToKgs;
                double totalHeightInMetres = totalHeightInInches * InchestoMetres;

                double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));

                return bmi;
            }
        }

        // calculate BMI category 
        [Display(Name = "Your BMI Category is")]
        public BMICategory BMICategory
        {
            get
            {
                double bmi = this.BMIValue;

                // calculate BMI category based on upper limits
                if (bmi <= UnderWeightUpperLimit)
                {
                    return BMICategory.Underweight;
                }
                else if (bmi <= NormalWeightUpperLimit)
                {
                    return BMICategory.Normal;
                }
                else if (bmi <= OverWeightUpperLimit)
                {
                    return BMICategory.Overweight;
                }
                else
                {
                    return BMICategory.Obese;
                }
            }
        }

        [Display(Name = "Your BMI information summary is: ")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public String HealthyWeight
        {
            get
            {
                double totalWeightInPounds = (WeightStones * 14) + WeightPounds;
                double totalHeightInInches = (HeightFeet * 12) + HeightInches;

                // do conversions to metric
                double totalWeightInKgs = totalWeightInPounds * PoundsToKgs;
                double totalHeightInMetres = totalHeightInInches * InchestoMetres;

                double kgToLose = 0;
                double maxhealthyWeight = 0;

                BMICategory currentCat = this.BMICategory;

                if (currentCat == BMICategory.Obese)
                {
                    maxhealthyWeight = NormalWeightUpperLimit * (Math.Pow(totalHeightInMetres, 2));
                    kgToLose = totalWeightInKgs - maxhealthyWeight;

                    return "\nYour Current weight is " + totalWeightInKgs + "kg"
                        + "\nIdeal maximum weight for someone " + totalHeightInMetres + "metres is " + maxhealthyWeight + "kg"
                        + "\nMinimum weight in kilogramms to lose is " + kgToLose;
                }
                else if (currentCat == BMICategory.Overweight)
                {
                    maxhealthyWeight = NormalWeightUpperLimit * (Math.Pow(totalHeightInMetres, 2));
                    kgToLose = totalWeightInKgs - maxhealthyWeight;

                    return "\nYour Current weight is " + totalWeightInKgs + "kg"
                        + "\nIdeal maximum weight for someone " + totalHeightInMetres + "metres is " + maxhealthyWeight + "kg"
                        + "\nMinimum weight in kilogramms to lose is " + kgToLose;
                }
                else if (currentCat == BMICategory.Underweight)
                {
                    maxhealthyWeight = NormalWeightUpperLimit * (Math.Pow(totalHeightInMetres, 2));
                    kgToLose = maxhealthyWeight - totalWeightInKgs;

                    return "\nYour Current weight is " + totalWeightInKgs + "kg"
                        + "\nIdeal maximum weight for someone " + totalHeightInMetres + "metres is " + maxhealthyWeight + "kg"
                        + "\nMaximum weight in kilogramms to put on is " + kgToLose;
                }
                else
                {
                    return "\nYou are a healthy weight";
                }
            }
        }
    }
}

