# Eğer Local makineden az cli kullanıyorsanız; 
# az login
# Eğer birden fazla aboneliğiniz varsa
# az account set "[SUBS ID]"
# 1. Aktif grupları listele:
az group list --output table
# 2. Gerekirse yeni bir resource-group oluştur:
az group create --name bademo-vm-cli-rg --location "westeurope"
# 3. Temel parametreler ile sanal makine oluştur.
az vm create \
            --resource-group bademo-vm-cli-rg \
            --name "bademo-win-cli" \
            --image "win2019datacenter" \
            --admin-username "turkay" \
            --admin-password "Password1234"
# 4. RDP Port'unu aç
az vm open-port \
            --resource-group bademo-vm-cli-rg \
            --name "bademo-win-cli"  \
            --port "3389" \


        