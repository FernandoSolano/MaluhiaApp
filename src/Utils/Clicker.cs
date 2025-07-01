using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Maluhia.Utils
{
    /// <summary>
    /// Handles the logic for performing random clicks within a user-defined area.
    /// </summary>
    public class Clicker
    {
        private Rectangle area;
        private CancellationTokenSource? cts;
        private readonly Random random = new();
        private int minInterval = 5;
        private int maxInterval = 10;

        public event Action<string>? StatusChanged;

        public void SetArea(Rectangle area)
        {
            this.area = area;
        }

        public void SetInterval(int minSeconds, int maxSeconds)
        {
            minInterval = minSeconds;
            maxInterval = maxSeconds;
        }

        public void Start()
        {
            if (area == Rectangle.Empty)
            {
                StatusChanged?.Invoke("Area not set.");
                return;
            }

            cts = new CancellationTokenSource();
            Task.Run(() => ClickLoop(cts.Token));
            StatusChanged?.Invoke("Clicking started.");
        }

        public void Stop()
        {
            cts?.Cancel();
            StatusChanged?.Invoke("Clicking stopped.");
        }

        private async Task ClickLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                int delay = (minInterval == maxInterval)
                    ? minInterval * 1000
                    : random.Next(minInterval * 1000, (maxInterval + 1) * 1000);
                await Task.Delay(delay, token);

                if (token.IsCancellationRequested) break;

                int x = random.Next(area.Left, area.Right);
                int y = random.Next(area.Top, area.Bottom);
                DoClick(x, y);
                StatusChanged?.Invoke($"Clicked at ({x}, {y})");
            }
        }

        private void DoClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MouseEventLeftDown | MouseEventLeftUp, 0, 0, 0, 0);
        }

        private const int MouseEventLeftDown = 0x02;
        private const int MouseEventLeftUp = 0x04;

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    }
}