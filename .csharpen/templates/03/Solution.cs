// ============================================================
//  第 3 关：字符串
//  这是你要填空的文件。找到每个 // TODO，把代码补完整。
//  改完后运行测试（见本关 README）。全绿即过关。
// ============================================================

namespace CSharpen.Level03;

public static class StringOps
{
    // -----------------------------------------------------------------
    // 任务 1：字符串插值
    // -----------------------------------------------------------------
    // C# 用 $"...{表达式}..." 把变量直接嵌进字符串，比拼接清晰得多。
    // 对照 C++：类似 std::format（C++20）或以前的 sprintf/<<，但内建在语法里。
    // 要求：返回 $"Hello, {name}!"，例如 name="Gavin" → "Hello, Gavin!"
    public static string Greet(string name)
    {
        // TODO: 用字符串插值返回 "Hello, {name}!"
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 2：字符串不可变
    // -----------------------------------------------------------------
    // C# 的 string 是不可变的：任何「修改」都会返回新字符串，原串不变。
    // 对照 C++：std::string 是可变的（可以原地改 s[0]）；C# 不行。
    // 要求：把整个字符串转成大写并返回（不改变入参本身——本来也改不了）。
    // 提示：string 有现成方法 ToUpper()。
    public static string Shout(string s)
    {
        // TODO: 返回 s 的全大写版本。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 3：首字母大写
    // -----------------------------------------------------------------
    // 综合用到：索引取字符、Substring 取子串、char 转大写、拼接。
    // 对照 C++：s.substr(1) ↔ s.Substring(1)；toupper ↔ char.ToUpper。
    // 要求：把首字母变大写、其余不变。空字符串原样返回。
    //       例："hello" → "Hello"，"" → ""
    // 提示：char.ToUpper(s[0]) 配合 s.Substring(1)。
    public static string Capitalize(string s)
    {
        // TODO: 首字母大写，其余不变；空串返回空串。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 4：统计字符出现次数
    // -----------------------------------------------------------------
    // 对照 C++：相当于遍历 std::string 计数，或 std::count。
    // 要求：返回字符 c 在 s 中出现的次数。
    // 提示：可以 foreach (char ch in s) 遍历并计数。
    public static int CountChar(string s, char c)
    {
        // TODO: 统计 c 在 s 中出现多少次。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 5：反转字符串
    // -----------------------------------------------------------------
    // 对照 C++：std::reverse(s.begin(), s.end())。C# 因为 string 不可变，
    //          要先转成 char[] 反转，再用 new string(...) 组回来。
    // 要求：返回反转后的字符串。例："abc" → "cba"
    // 提示：s.ToCharArray() → System.Array.Reverse(arr) → new string(arr)。
    public static string Reverse(string s)
    {
        // TODO: 返回 s 反转后的结果。
        throw new System.NotImplementedException();
    }

    // -----------------------------------------------------------------
    // 任务 6：回文判断
    // -----------------------------------------------------------------
    // 要求：判断 s 是否回文（正读反读一样）。判断时忽略大小写。
    //       例："Level" → true（忽略大小写后 level 反转还是 level）。
    //       空串视为回文（true）。
    // 提示：可以复用上面的 Reverse，并先统一大小写比较。
    public static bool IsPalindrome(string s)
    {
        // TODO: 忽略大小写判断 s 是否回文。
        throw new System.NotImplementedException();
    }
}
