using System;
using System.Text;

namespace Cross
{
    // Builds a Cross/X and outputs it to the console.
    public class CrossBuilder : IPrint
    {
        // The spacing to the left of the Cross.
        private int leftPadding { get; set; }

        // The spacing between the 2 lines of the Cross.
        private int centerPadding { get; set; }

        // Outputs to console the cross shape.
        public void Print(int height)
        {
            // The Cross will look different depending if height is odd or even.
            bool isEven = (height % 2 == 0) ? true : false;
            int center = 0;
            int centerIncrement = 0;

            if (isEven)
            {
                center = (height / 2) - 1;
                centerIncrement = 4;
            }
            else
            {
                center = height / 2;
                centerIncrement = 3;
            }

            leftPadding = 0;
            centerPadding = (height * 2) - centerIncrement;
            bool toCenter = true;
            for (int i = 0; i < height; i++)
            {
                // The Center of the Cross.
                if (i == center)
                {
                    string row;
                    toCenter = false;

                    if (isEven)
                    {
                        row = FormatRow("**");
                        Console.WriteLine(row);
                        Console.WriteLine(row);
                        ++i;
                    }
                    else
                    {
                        row = FormatRow("*");
                        Console.WriteLine(row);
                    }
                }
                else
                {
                    string row = FormatRow("*");
                    Console.WriteLine(row);
                }

                // Update the spacing for the next row.
                UpdatePadding(toCenter);
            }
        }

        // Formats the string to create a section of the X.
        private string FormatRow(string text)
        {
            StringBuilder sb = new StringBuilder();

            // Add the spacing on the left-side.
            sb.Append(AddRepeatedText(' ', leftPadding));

            // Add the line section.
            sb.Append(text);

            // Add the spacing in between the lines.
            sb.Append(AddRepeatedText(' ', centerPadding));

            // Add another asterisk to the right side if it's not the center.
            if (centerPadding > 0)
            {
                sb.Append(text);
            }

            return sb.ToString();
        }

        // Creates a string of a repeated character "count" times.
        private string AddRepeatedText(char c, int count)
        {
            if (count <= 0)
                return "";

            return new string(c, count);
        }

        // Update the padding values for the next row.
        private void UpdatePadding(bool toCenter)
        {
            if (toCenter)
            {
                leftPadding += 2;
                centerPadding -= 4;
            }
            else
            {
                leftPadding -= 2;
                centerPadding += 4;
            }
        }

    }
}
