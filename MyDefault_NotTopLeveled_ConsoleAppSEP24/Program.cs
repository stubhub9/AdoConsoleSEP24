namespace MyDefault_NotTopLeveled_ConsoleAppSEP24
{
    internal class Program
    {
        #region  Fields and Properties
        //  Gets the original background [black], for reset on close.
        static readonly ConsoleColor bgColor = Console.BackgroundColor;

        /*  Can be set to any color between Black 0 & White 15; 
         *  the terminal's background will be the next color. */
        static ConsoleColor _newColor = ConsoleColor.DarkRed;

        /// <summary>
        ///  Can be set to any color between Black 0 & LESS THAN White 15; 
        ///  the terminal or row background will be the next color.
        /// </summary>
        public static ConsoleColor NewColor
        {
            get
            {
                _newColor++;

                if (_newColor == ConsoleColor.White)
                {
                    _newColor = ConsoleColor.DarkBlue;
                }
                return _newColor;
            }
            set
            {
                if (((ConsoleColor)0 <= value) && (value < (ConsoleColor)15))
                {

                    // New starting color.
                    _newColor = value;
                }
            }
        }

        #endregion  Fields and Properties
        #region  Main Constructor

        //  Give it to me like a constructor, instead of TopLevel Template.
        static void Main ( string [] args )
        {
            //  New terminal color
            Console.BackgroundColor = NewColor;
            Console.Clear ();
            //  New command line row background.
            Console.BackgroundColor = NewColor;






            //    static void Main ( string [] args )
            //{
            //    Console.WriteLine ( "Hello, World!" );
        }
        #endregion  Main Constructor

    }
}
