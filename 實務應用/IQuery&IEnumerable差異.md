 一、IQueryable
📌 1️⃣ 定義與特性
IQueryable 繼承自 IEnumerable，同時支援「延遲執行」與「查詢轉換」。

主要用途是：建構查詢 (Query)，讓底層的資料來源（例如資料庫）去執行最終的查詢。

例如在 Entity Framework Core 中，DbSet<T> 就是 IQueryable<T>。

📌 2️⃣ 關鍵特點
✅ 延遲執行（Deferred Execution）
只會在真正執行（例如 ToList()、First()）時，才發送查詢。
✅ 查詢轉換
LINQ 的運算子（像 Where()、Select()、GroupBy()）會被轉換成底層（如 SQL）的查詢語法。


二、IEnumerable
📌 1️⃣ 定義與特性
IEnumerable 是最基本的可列舉集合介面。

代表的是「已經在記憶體中」的一個集合，或者是可以逐步產生資料的序列。

LINQ-to-objects 運算子會在 應用程式記憶體中執行。

📌 2️⃣ 關鍵特點
✅ 支援 延遲執行（例如 yield return）
✅ 適合在 記憶體內部進行處理（例如陣列、清單、集合）


🔷 三、兩者比較
| 項目               | IQueryable            | IEnumerable                    |
| ---------------- | --------------------- | ------------------------------ |
| 資料來源             | 資料庫、外部來源（SQL、NoSQL 等） | 記憶體內的集合（List、Array、Dictionary） |
| 查詢執行位置           | 轉成 SQL 等語言，由資料庫執行     | 直接在記憶體中執行                      |
| 執行效率             | 資料庫執行（效能好，避免載入全部資料）   | 需要先載入全部資料（記憶體與 CPU 壓力）         |
| 延遲執行支援           | ✅                     | ✅                              |
| 適合情境             | 資料庫查詢、大型資料集           | 小型資料集、API 回傳後的處理               |
| LINQ-to-entities | ✅                     | ❌                              |
| LINQ-to-objects  | ❌                     | ✅                              |
