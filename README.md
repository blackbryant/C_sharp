# C# 進階之路

紀錄C#基本到進階所有範例

- 一切從型別開始
  - .NET 型別
    - 五大型別
    - 參考型別特徵
    - 型別物件與參考型別執行個體比較
    - 實值型別特徵
  - 型別變異性
    - 不變性、共變性與逆變性
  - 變數
    - 變數內容
  - 指派運算子的運作
- 泛型的設計
  - <a href="https://github.com/blackbryant/C_sharp/blob/main/%E6%B3%9B%E5%9E%8B%E7%9A%84%E8%A8%AD%E8%A8%88/GenericExample.linq" target="_blank">泛型的定義  </a>
  - 泛型條件約束
  - 泛型中的靜態設計
- 成員的設計
  - 欄位
    - 欄位的定義
    - 欄位的設計
  - 屬性
    - 屬性的定義
    - 屬性的設計
  - 方法
    - 方法的定義
    - 方法封裝設計
    - 方法參數設計
    - 方法的繼承式多型設計
    - 方法多載設計
    - 靜態方法與擴充方法的設計
    - 區域方法的設計
    - 執行個體與靜態方法的選擇？
  - 建構式
    - 建構式的定義
    - 基底與衍生型別建構式的關係
    - 建構式多載設計
    - 物件的建構流程
  - 事件
    - 事件的定義
    - 事件的設計
    - 非同步議題
  - 索引子
    - 索引子的定義
    - 索引子的設計
    - 唯讀索引子
  - 常數
  - 巢狀型別
- 抽象通論
  - 定義抽象
  - 類別與演算法的抽象
- 結構的設計
  - 結構的定義與特徵
  - 結構設計方針
  - Framework 中重要的結構型別
    - `Nullable<T>`
    - `ValueTuple` 家族
    - `ValueTask` 與 `ValueTask<T>`
  - Boxing & Unboxing
    - Boxing 原理
    - 利用泛型解決 Boxing 問題
  - 防禦性複製
- 類別的設計
  - 類別的定義與特徵
  - 類別的設計
    - 內聚性
    - 抽象類別
  - 靜態類別的設計
- 介面的設計
  - 介面的定義
  - 實作介面成員 (< C# 8.0)
    - 一般實作
    - 抽象實作
    - 明確實作
  - 介面的擴充設計
  - C# 8 對於介面的增強
  - 泛型介面的變異性設計
- 委派的設計
  - 委派的定義
  - Framework 中既有的委派型別
  - 非泛型委派的變異性議題
  - 泛型委派的變異性設計
- 列舉的設計
  - 列舉的定義
  - 使用列舉的意圖
  - 旗標式列舉
- <a href="https://github.com/blackbryant/C_sharp/blob/main/%E7%89%A9%E4%BB%B6%E5%B0%8E%E5%90%91%E8%A8%AD%E8%A8%88%E6%87%89%E7%94%A8/%E4%B8%8D%E5%8F%AF%E8%AE%8A%E8%A8%AD%E8%A8%88/ImmutableExample.linq" target="_blank">不可變設計</a>
  - 不可變設計的定義
  - 不可變設計方針
- Lambda 與迭代器
  - Lambda 的演進
  - 迭代器原理與實作
- 反射
  - 何謂反射
  - 動態載入組件
  - 動態建立執行個體
  - 取得成員資訊
  - 反射與泛型
- Attribute
  - Attribute 的定義
  - 自訂 Attribute
  - Attribute 參數
  - 使用自訂 Attribute
  - Attribute 應用實例
- SOLID 六大原則
  - 單一職責
  - 里式替換
  - 倚賴倒置
  - 介面隔離
  - 開閉
  - 最小知識
- 物件導向設計應用
  - 三原則定義
  - 三原則的運用實例
  - 類別與介面的選擇
  - 介面與委派的選擇
  - `Enumerable.Where` 的設計之美
  - <a href="https://programdoubledragon.blogspot.com/2024/12/c-di.html" target="_blank"> DI 與 IoC </a>
    - <a href="https://github.com/blackbryant/C_sharp/blob/main/%E7%89%A9%E4%BB%B6%E5%B0%8E%E5%90%91%E8%A8%AD%E8%A8%88%E6%87%89%E7%94%A8/DiExample.linq" target="_blank">DiExample.linq</a>
    - <a href="https://github.com/blackbryant/C_sharp/blob/main/%E7%89%A9%E4%BB%B6%E5%B0%8E%E5%90%91%E8%A8%AD%E8%A8%88%E6%87%89%E7%94%A8/ServiceLocatorExample.linq" target="_blank">ServiceLocatorExample.linq</a>
  - 聚合設計
- 基礎重構
  - 何時需要重構？
  - 基本重構技巧
