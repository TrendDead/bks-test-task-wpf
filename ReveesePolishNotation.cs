using System;
using System.Collections.Generic;

namespace bks_test_task_wpf
{
    /// <summary>
    /// Класс работы с обратной польской нитацией
    /// </summary>
    public static class ReversePolishNotation
    {
        /// <summary>
        /// Преобразует выражение в обратную польскую запись
        /// </summary>
        /// <param name="mathematicalExpression"> Математическое выражение </param>
        /// <returns> Обратная польская запись выражения </returns>
        public static string ConvertToPolishNotation(string mathematicalExpression)
        {
            Stack<char> operationsStack = new Stack<char>();

            char lastOperation;

            string result = string.Empty;
            string number = "";

            mathematicalExpression = mathematicalExpression.Replace(" ", "");

            for (int i = 0; i < mathematicalExpression.Length; i++)
            {
                if (Char.IsDigit(mathematicalExpression[i]))
                {
                    number += mathematicalExpression[i];
                    if (i == mathematicalExpression.Length - 1)
                    {
                        result += number + " ";
                    }
                    continue;
                }

                if (IsOperation(mathematicalExpression[i]))
                {
                    if (number != "")
                    {
                        result += number + " ";
                        number = "";
                    }

                    if (!(operationsStack.Count == 0))
                    {
                        lastOperation = operationsStack.Peek();
                    }
                    else
                    {
                        operationsStack.Push(mathematicalExpression[i]);
                        continue;
                    }

                    if (GetOperationPriority(lastOperation) < GetOperationPriority(mathematicalExpression[i]))
                    {
                        operationsStack.Push(mathematicalExpression[i]);
                        continue;
                    }
                    else
                    {
                        result += operationsStack.Pop() + " ";
                        operationsStack.Push(mathematicalExpression[i]);
                        continue;
                    }
                }

                if (mathematicalExpression[i].Equals('('))
                {
                    if (number != "")
                    {
                        result += number + " ";
                        number = "";
                    }
                    operationsStack.Push(mathematicalExpression[i]);
                    continue;
                }

                if (mathematicalExpression[i].Equals(')'))
                {
                    if (number != "")
                    {
                        result += number + " ";
                        number = "";
                    }
                    while (operationsStack.Peek() != '(')
                    {
                        result += operationsStack.Pop() + " ";
                    }
                    operationsStack.Pop();
                }
            }

                while (!(operationsStack.Count == 0))
            {
                result += operationsStack.Pop() + " ";
            }

            return result;
        }

        /// <summary>
        /// Определяет приоритет операции
        /// </summary>
        /// <param name="symbol"> Символ операции </param>
        /// <returns> Приоритет операции </returns>
        private static int GetOperationPriority(char symbol)
        {
            switch (symbol)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 0;
            }
        }

        /// <summary>
        /// Является ли символ математической операцией
        /// </summary>
        /// <param name="symbol"> Символ для проверки</param>
        public static bool IsOperation(char symbol)
        {
            if (symbol == '+' ||
                symbol == '-' ||
                symbol == '*' ||
                symbol == '/')
                return true;
            else
                return false;
        }
    }
}
