namespace Chess
{
    partial class Validation
    {
        public bool IsFormatValid(string lowerCaseMove)
        {
            const string MoveRegExExpression = "([a-h]{1}[1-8]{1}[a-h]{1}[1-8]{1})";

            if (lowerCaseMove.Length == 4)
            {
                if (CommonUtils.CheckRegEx(lowerCaseMove, MoveRegExExpression))
                {
                    return true;
                }
            }
            else if (lowerCaseMove.Length == 2)
            {
                if (lowerCaseMove == "00")  //castle on king side
                {
                    return true;
                }
            }
            else if (lowerCaseMove.Length == 3)
            {
                if (lowerCaseMove == "000")  //castle on queen side
                {
                    return true;
                }
            }
            else if (lowerCaseMove.Length == 1)
            {
                if (
                    (lowerCaseMove == "r") //reset board
                    || (lowerCaseMove == "f") //flip the board over
                    || (lowerCaseMove == "s") //save the game
                    || (lowerCaseMove == "q") //quite the game
                    )
                {
                    return true;
                }
            }

            return false;
        }
    }
}