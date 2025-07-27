//
// ベンチマークに利用するソースコードを自動実行するソースコード
//
// ビルド&実行方法（Windows）：
//   csc source_code_gen.cs;
//   ./source_code_gen.exe 0 1000 > target_source/main_0.cs
//   ./source_code_gen.exe 1 1000 > target_source/main_1.cs
using System;
using System.Collections.Generic;

namespace CscBenchmark
{

class Program
{
  static void Main(string[] args)
  {
    if (args.Length != 2)
    {
      Console.WriteLine("./source_code_gen.exe <i> <count>");
      return;
    }
    Console.WriteLine("using System;");
    Console.WriteLine("#pragma warning disable 0169");
    Console.WriteLine("namespace CscBenchmark" + args[0]);
    Console.WriteLine("{");
    Console.WriteLine("class Gen<T1, T2, T3, T4> {}");
    string[] gen_types = { "int", "double", "string", "Guid" };
    List<string> gen_n_types = new List<string>();
    for (int i = 0; i < gen_types.Length; ++i)
    {
      for (int j = 0; j < gen_types.Length; ++j)
      {
        for (int k = 0; k < gen_types.Length; ++k)
        {
          for (int l = 0; l < gen_types.Length; ++l)
          {
            string gen_n = "Gen<" + gen_types[i] + ", " + gen_types[j] + ", " + gen_types[k] + ", " + gen_types[l] + ">";
            gen_n_types.Add(gen_n);
          }
        }
      }
    }
    Console.WriteLine("class DeepNest");
    Console.WriteLine("{");
    int count = 0;
    int max_count = Int32.Parse(args[1]);
    for (int i = 0; i < gen_n_types.Count; ++i)
    {
      if (count > max_count) { break; }
      for (int j = 0; j < gen_n_types.Count; ++j)
      {
        if (count > max_count) { break; }
        for (int k = 0; k < gen_n_types.Count; ++k)
        {
          if (count > max_count) { break; }
          for (int l = 0; l < gen_n_types.Count; ++l)
          {
            if (count > max_count) { break; }
            string gen = "Gen<" + gen_n_types[i] + ", " + gen_n_types[j] + ", " + gen_n_types[k] + ", " + gen_n_types[l] + ">";
            Console.WriteLine("  " + gen + " value" + count + ";");
            ++count;
          }
        }
      }
    }
    Console.WriteLine("} // class DeepNest");
    Console.WriteLine("}");
  }
}


} // namespace CscBenchmark
