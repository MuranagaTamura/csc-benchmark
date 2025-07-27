C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc source_code_gen.cs

for ($i = 0; $i -lt 100; $i++)
{
  .\source_code_gen.exe $i 1000 > .\target_source\main_$i.cs
}
"public class Program { static void Main(string[] args) {} }" | Out-File -FilePath ".\target_source\main.cs" -Encoding UTF8

rm source_code_gen.exe
