using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace async_await_01
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var waitingTask = WaitExampleAsync(); // 開始等待但不等它完成

            // 主線程持續做其他事情（例如不斷印出）
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main doing other work... {i}..{DateTime.Now}");
                await Task.Delay(1000); // 模擬主線程的其他工作（短暫非同步延遲）
            }

            await waitingTask; // 最後才等 WaitExampleAsync 結束
            Console.WriteLine("Main finished all work.");

            Console.ReadLine();
        }

        public static async Task WaitExampleAsync()
        {
            Console.WriteLine($"Start async wait...{DateTime.Now}");
            await Task.Delay(2000); // 模擬長時間非同步等待
            Console.WriteLine($"Finished waiting asynchronously!.....{DateTime.Now}");
        }
    }
}
