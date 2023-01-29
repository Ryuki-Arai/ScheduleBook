/// <summary>
/// 曜日情報
/// 7種の他、祝日とNone(カレンダー上の空白)に用いるパラメータが存在
/// </summary>
public enum Week
{
    None = -1,
    Sunday = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Holiday = 7,
}