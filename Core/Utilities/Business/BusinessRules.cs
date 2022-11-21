using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logigcs)
        {
            foreach (var logic in logigcs)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}