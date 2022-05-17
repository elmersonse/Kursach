using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kursach
{
    class Util
    {
        public static void CheckLetter(object sender, TextCompositionEventArgs e)
        {
            string c = e.Text;
            if (!Char.IsLetter(c[0]) && !Char.IsControl(c[0]) && !Char.IsWhiteSpace(c[0]))
            {
                e.Handled = true;
            }
        }

        public static void CheckNumber(object sender, TextCompositionEventArgs e)
        {
            string c = e.Text;
            if (!Char.IsNumber(c[0]))
            {
                e.Handled = true;
            }
        }

        public static void CheckLogin(object sender, TextCompositionEventArgs e)
        {
            string c = e.Text;
            if(!Char.IsLetterOrDigit(c[0]) && !Char.IsControl(c[0]))
            {
                e.Handled = true;
            }
        }
    }
}
