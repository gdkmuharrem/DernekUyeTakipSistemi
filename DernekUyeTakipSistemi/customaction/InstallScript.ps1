# Access Database Engine 32-bit yükleyici dosyasının yolu
$installerPath = "AccessDatabaseEngine.exe"

# Yükleyiciyi sessiz modda çalıştırma
Start-Process -FilePath $installerPath -ArgumentList "/quiet" -Wait
