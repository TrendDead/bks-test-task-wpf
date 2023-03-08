using System.Data;
using System.Collections.Generic;

namespace bks_test_task_wpf
{
    public static class PolishNotationCalculator
    {
        /// <summary>
        /// Вычислить результат выраения
        /// </summary>
        /// <param name="polishNotationExpression">выражение в формате обратной Польской натации</param>
        /// <returns>Результат выражения</returns>
        public static string GetResultCalculate(string polishNotationExpression)
        {
            string[] symbols = polishNotationExpression.Trim().Split(' ');

            Stack<string> operationsStack = new Stack<string>();

            foreach (var symbol in symbols)
            {
                if(!IsOperation(symbol))
                {
                    operationsStack.Push(symbol);
                }
                else
                {
                    string operator2 = operationsStack.Pop();
                    string operator1 = operationsStack.Pop();
                    operationsStack.Push(Calculate(operator1, operator2, symbol));
                }
            }

            var result = operationsStack.Pop();
            return result;
        }

        private static string Calculate(string operator1, string operator2, string operation)
        {
            return new DataTable().Compute(operator1 + operation + operator2, null).ToString();
        }

        /// <summary>
        /// Является ли символ математической операцией
        /// </summary>
        /// <param name="symbol"> Строка для проверки</param>
        private static bool IsOperation(string symbol)
        {
            if (symbol == "+" ||
                symbol == "-" ||
                symbol == "*" ||
                symbol == "/")
                return true;
            else
                return false;
        }
    }
}
