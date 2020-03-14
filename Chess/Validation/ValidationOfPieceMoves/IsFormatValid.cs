namespace Chess
{
    partial class Validation
    {
        public bool IsFormatValid(string lowerCaseMove)
        {
            // !!! sort out reg ex ??? .. this doesn't work
            //const string RegExExpression = "([a-h]{1}[1-8]{1}[a-h]{1}[1-8]{1}) | ([0]{1}) | ([0]{2}) | ([r]{1}) | ([q]{1) | ([s]{1})";
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
                if (lowerCaseMove == "00")
                {
                    return true;
                }
            }
            else if (lowerCaseMove.Length == 1)
            {
                if ((lowerCaseMove == "0") || (lowerCaseMove == "r") || (lowerCaseMove == "s") || (lowerCaseMove == "q"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}