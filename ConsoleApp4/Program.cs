using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0910
{
    class Class7
    {
        enum GameMessage { NONE, UP, DOWN, CORRECT, QUIT } //정의

        static void Main()
        {
            int[] com = new int[3];  //컴퓨터
            int[] user = new int[3]; //사용자   
            bool aFlag = true;

            while (aFlag)
            {
                #region 컴퓨터 난수
                Random rand = new Random();
                com[0] = rand.Next(1, 10); //0번째는 중복검사를 할 필요가 없이 바로 저장


                int cnt = 1;
                while (cnt < com.Length)
                {
                    int temp = rand.Next(1, 10);
                    //뽑은 난수가 앞부분의 값들과 중복이 되는지 체크
                    bool bFlag = true; //기본값은 중복이 아닌것으로 설정
                    for (int i = 0; i < cnt; i++)
                    {
                        if (com[i] == temp)
                        {
                            bFlag = false; //중복이면 false
                            break;
                        }
                    }

                    if (bFlag) //중복이 아닌경우
                    {
                        com[cnt] = temp;
                        cnt++;
                    }
                }

                #endregion
                Console.WriteLine("야구게임입니다. 0~9의 숫자를 맞춰보세요\n");
                while (true)
                {
                    #region 사용자 입력
                    Console.Write("입력 (종료: Q): ");
                    string str = Console.ReadLine();

                    if (str.ToLower() == "q")
                    {
                        Console.WriteLine("종료합니다");
                        aFlag = false;
                        break;
                    }
                    int st = 0, ba = 0;
                    while (true)
                    {

                        //자릿수가 3자리인지 체크
                        if (str.Length != 3)
                        {
                            Console.WriteLine("3자리를 입력하세요.\n");
                            break;
                        }

                        //0을 입력한 경우 체크
                        if (str.Contains("0"))
                        {
                            Console.WriteLine("1~9까지의 숫자 3개를 입력하세요.\n");
                            break;
                        }

                        //숫자인지 체크
                        //int userNum = int.Parse(Console.ReadLine()); //289 "abc"  

                        int userNum;
                        if (!int.TryParse(str, out userNum))
                        {
                            Console.WriteLine("숫자 3자리를 입력하세요.\n");

                        }
                        else
                        {
                            int num1 = userNum / 100;           //1번째 자리   2
                            int num2 = (userNum / 10) % 10;     //2번째 자리   8
                            int num3 = userNum % 10;            //3번째 자리   9

                            //중복된 숫자가 있는지 체크 
                            if (num1 == num2 || num1 == num3 || num2 == num3)
                            {
                                Console.WriteLine("중복되지 않는 1~9까지의 숫자 3개를 입력하세요.\n");
                            }
                            else
                            {
                                user[0] = num1;
                                user[1] = num2;
                                user[2] = num3;


                            }
                        }


                        #endregion

                        #region 임시로 배열 내용을 출력
                        //Console.Write("COM : ");
                        //foreach (int num in com)
                        //{
                        //    Console.Write(num + ", ");
                        //}
                        //Console.WriteLine();

                        //Console.Write("USR : ");
                        //foreach (int num in user)
                        //{
                        //    Console.Write(num + ", ");
                        //}
                        //Console.WriteLine();
                        #endregion

                        #region 처리로직(판단)


                        for (int u = 0; u < 3; u++)
                        {
                            for (int c = 0; c < 3; c++)
                            {
                                if (user[u] == com[c]) //값이 같은것
                                {
                                    if (u == c) //인덱스(순서)까지 같은것
                                    {
                                        st++;

                                    }
                                    else
                                    {
                                        ba++;

                                    }
                                }
                            }
                        }

                        Console.WriteLine($"=====> {st}스트라이크 {ba}볼");
                        Console.WriteLine();
                        break;
                    }
                    if (st == 3)
                    {
                        Console.WriteLine("축하합니다\n");
                        Console.WriteLine("계속 하시겠습니까? 1. 계속  2. 종료");
                        st = Convert.ToInt32(Console.ReadLine());
                        if (st == 1)
                            break;
                        else if (st == 2)
                        {
                            aFlag = false;
                            break;
                        }
                    }
                    #endregion
                }
            }
        }
    }
}

