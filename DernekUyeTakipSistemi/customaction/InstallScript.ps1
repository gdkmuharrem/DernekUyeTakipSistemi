# Access Database Engine 32-bit yükleyici dosyasýnýn yolu
$installerPath = "AccessDatabaseEngine.exe"

# Yükleyiciyi sessiz modda çalýþtýrma
Start-Process -FilePath $installerPath -ArgumentList "/quiet" -Wait
