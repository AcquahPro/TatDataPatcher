Add-Type -AssemblyName System.Drawing
$bmp = New-Object System.Drawing.Bitmap(256,256)
$g = [System.Drawing.Graphics]::FromImage($bmp)
$g.Clear([System.Drawing.Color]::FromArgb(0,120,215))
$g.FillEllipse([System.Drawing.Brushes]::White, 20,20,216,216)
$font = New-Object System.Drawing.Font("Arial",96,[System.Drawing.FontStyle]::Bold)
$g.DrawString("CSV", $font, [System.Drawing.Brushes]::White, 55,70)
$g.Save()
$bmp.Save("icon.png", [System.Drawing.Imaging.ImageFormat]::Png)
$bmp.Save("icon.ico", [System.Drawing.Imaging.ImageFormat]::Icon)
Write-Host "Icon files generated: icon.ico, icon.png"