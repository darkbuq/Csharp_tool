using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_run_01
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 啟動支線計算（跑在背景執行緒）
            var longRunningTask = Task.Run(() => HeavyCalculation());

            // 主線任務持續做自己的事（印出時間）
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"主線工作中... {i} - {DateTime.Now}");
                //await Task.Delay(1000); // 模擬主線每秒執行一次工作
                Thread.Sleep(500);
            }

            // 等支線任務做完
            await longRunningTask;
            Console.WriteLine("支線計算完成！");
            Console.ReadLine();
        }

        public static void HeavyCalculation()
        {
            Console.WriteLine("支線開始大量計算...");
            double result = 0;
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"     支線工作中... {i} - {DateTime.Now}");
                Thread.Sleep(500);
            }
            Console.WriteLine("支線完成計算！");
        }
    }
}
