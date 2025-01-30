namespace _Project.Scripts.Utils
{
    public class StopWatchTimer
    {
        private readonly float _cooldown;
        private float _timer;
        private bool isReady;
        private bool isStopped;

        public bool IsReady => isReady;


        public StopWatchTimer(float cooldown)
        {
            _cooldown = cooldown;
            isReady = true;
        }

        public void Update(float time)
        {
            if (isReady || isStopped) return;

            if (_cooldown > _timer)
            {
                _timer += time;
            }
            else
            {
                isReady = true;
            }
        }

        public void Reset()
        {
            isReady = false;
            isStopped = false;
            _timer = 0f;
        }

        public void Stop()
        {
            isStopped = true;
        }

        public void Continue()
        {
            isStopped = false;
        }
    }
}