using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Bird
    {
        [Key]
        public int Id { get; set; }


        [Range(0, 255)]
        [DisplayName("Red")]
        public int Red { get; set; }
        [Range(0, 255)]
        [DisplayName("Green")]
        public int Green { get; set; }
        [Range(0, 255)]
        [DisplayName("Blue")]
        public int Blue { get; set; }

        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public float Price { get; set; }

        public Bird()
        {

        }

        public Bird(int red, int green, int blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Price = (float)CalculateColorPrice(red, green, blue);
        }

        // Calculate Price
        protected double CalculateColorPrice(int red, int green, int blue)
        {
            if (red == 0 && green == 170 && blue == 230)
            {
                return 8.0;
            }
            else if (Math.Abs(red - 0) >= 20 || Math.Abs(green - 170) >= 20 || Math.Abs(blue - 230) >= 20)
            {
                return 0.0;
            }
            else
            {
                return (8.0 - Math.Max(Math.Abs(red - 0), Math.Max(Math.Abs(green - 170), Math.Abs(blue - 230))) * 0.1);
            }
        }
    }
}
