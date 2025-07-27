$max_count = 10
$sum_time = 0.0
for ($i = 0; $i -lt $max_count; $i++)
{
  $mesureed_time = Measure-Command { C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc .\target_source\*.cs }
  $sum_time += $mesureed_time.TotalMilliseconds;
}
$result_time = $sum_time / $max_count
Write-Host "$($result_time) [msec]"
rm main.exe
