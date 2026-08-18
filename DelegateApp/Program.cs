namespace DelegateApp;


// 델리게이트 (Delegate : 대리자) ==> Action / Event 문법 ==> 디자인 패턴 (옵저버 패턴, 이벤트 버스)
// 메서드(함수)를 저장하는 타입
// int a = 10;
// 델리게이트 sum = 함수;
// 델리게이트명 변수명 = 함수;
// public void Sum(int a, int b)

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        player.OnPlayerDie?.Invoke();
    }
}

class Player
{
    // 1. 델리게이트 선언
    public delegate void PlayerDieHandler();
    // 2. 델리게이트 이벤트
    public PlayerDieHandler OnPlayerDie;

    public Player()
    {
        OnPlayerDie += Die;
    }
    
    public void Die()
    {
        Console.WriteLine("Player 사망");
    }

}