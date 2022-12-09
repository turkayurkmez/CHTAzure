#1. ACR oluşturduk
#2. Access Keys içerisinden Admin-user seçeneği enabled yapıldı
#3. Yerel makinemizden Azure Container Registry'e login olduk :)
#     -- Ne yazık ki ben DNS'den dolayı biraz zaman kaybettim

az acr login -n bademo2

#4. oluşturulan docker image'inin etiketini güncelledik
docker tag  webappimg:v1 bademo2.azurecr.io/webappimg:v1
#5. Belirtilen registry'e gönderdik:
docker push bademo2.azurecr.io/webappimg:v1
