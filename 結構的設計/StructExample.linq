/*
結構的定義：
1.Struct: 是值型別（Value Type），通常用於小型、輕量的數據結構，以減少堆分配（Heap Allocation），提高性能。
    特性：(1) 適用於 小型、不可變（Immutable） 的數據
         (2) 避免繼承（因為 struct 不能繼承其他 struct）
         (3) readonly struct 可防止修改字段，提高效能。
         (4) 避免包含大量字段，以防止過大的複製成本。
         (5) 隱含繼承自 System.ValueType： 所有結構都隱含繼承自 System.ValueType
    應用: 防禦性複製（Defensive Copying）=>防止無意的修改

2. Framework 中重要的結構型別：
   (1) Nullable<T> : 結構允許實值型別（例如 int、double、bool）具有 null 值

   (2) ValueTuple : 一組輕量級的結構，用於將多個值組合在一起。
                    方便方式來建立傳回多個值，而無需定義自訂類別或結構

3. ValueTask 與 ValueTask<T>
   (1) ValueTask 和 ValueTask<T> 用於表示可能同步或非同步操作，ValueTask<T> 是 Task<T> 的替代方案，減少異步方法中的堆分配。
   (2) ValueTask 的主要優勢在於減少堆積分配，從而提高效能與記憶體的配置

*/

// Nullable<T> 例子

int? nullableInt = null;

if (nullableInt.HasValue)
{
    Console.WriteLine($"Value: {nullableInt.Value}");
}
else
{
    Console.WriteLine("No value assigned.");
}

// struct 例子
public readonly struct Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

Point p1 = new Point(10,12);
p1.X = 12;  //修改無效
Console.WriteLine(((MutableStruct)obj).Value); // 還是 10


// ValueTuple
(string name, int age) person = ("John", 30);
Console.WriteLine($"Name: {person.name}, Age: {person.age}");


//

