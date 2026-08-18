namespace DelegateApp;


// 델리게이트 (Delegate : 대리자) ==> Action / Event 문법 ==> 디자인 패턴 (옵저버 패턴, 이벤트 버스)
// 메서드(함수)를 저장하는 타입
// int a = 10;
// 델리게이트 sum = 함수;
// 델리게이트명 변수명 = 함수;
// public void Sum(int a, int b)

// Action
// public event 델리게이트 델리게이트유형

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player(100);
        // 이벤트 구독 (기초적인 옵저버 패턴)
        player.OnPlayerDie += GameOver;
        player.OnHpChanged += PlayerDamaged;
        
        player.TakeDamage(20);
        player.TakeDamage(30);
        player.TakeDamage(50);
    }

    static void GameOver()
    {
        Console.WriteLine("주인공 사망! Game Over!");
    }

    static void PlayerDamaged(int hp)
    {
        Console.WriteLine($"주인공 피격 HP: {hp}");
    }
}

public interface IDamageable
{
    void TakeDamage(int damage);
}


// Action 
// 델리게이트 문법을 간결하게 선언할 수 있는 .NET 내장 델리게이트
// 반환타입이 없는 델리게이트 : Action
// 반환타입이 있는 델리게이트 : Action<T> , Action<T, T>, ... 16 파라메터를 지원
class Player : IDamageable
{
    // 필드 선언
    private int _hp;
    // 1. 델리게이트 선언
    public delegate void PlayerDieHandler();
    // 2. 델리게이트 이벤트
    public event PlayerDieHandler OnPlayerDie;
    
    // Action 문법
    public event Action<int> OnHpChanged;

    // Func 문법
    
    public Player(int hp)
    {
        _hp = hp;
    }
    
    public void Die()
    {
        Console.WriteLine("Player 사망");
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        OnHpChanged?.Invoke(_hp);
        
        if (_hp <= 0)
        {
            // 주인공 사망
            OnPlayerDie?.Invoke();
        }
    }
}