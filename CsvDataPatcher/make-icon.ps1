Add-Type -AssemblyName System.Drawing
$bmp = New-Object System.Drawing.Bitmap(256,256)
$g = [System.Drawing.Graphics]::FromImage($bmp)
$g.Clear([System.Drawing.Color]::FromArgb(0,120,215))
$g.FillEllipse([System.Drawing.Brushes]::White, 20,20,216,216)
$font = New-Object System.Drawing.Font("Arial",96,[System.Drawing.FontStyle]::Bold)
$g.DrawString("CSV", $font, [System.Drawing.Brushes]::White, 55,70)
$bmp.Save("icon.png", [System.Drawing.Imaging.ImageFormat]::Png)
$g.Dispose()
$font.Dispose()
$bmp.Dispose()

# Build an ICO containing the PNG image. This produces a valid application icon
# for the executable and Windows taskbar.
$png = [IO.File]::ReadAllBytes("icon.png")
$header = [byte[]](0,0,1,0,1,0,0,0,0,0,1,0,32,0)
$size = [BitConverter]::GetBytes([uint32]$png.Length)
$offset = [BitConverter]::GetBytes([uint32]22)
[IO.File]::WriteAllBytes("icon.ico", $header + $size + $offset + $png)
Write-Host "Icon files generated: icon.ico, icon.png"