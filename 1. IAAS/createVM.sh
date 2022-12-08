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
#5. Oluşturulan VM'in public IP Adresini bulun:
az vm list-ip-addresses \
              --resource-group bademo-vm-cli-rg \
              --name "bademo-win-cli"  \
              --output table


### LAB 2.2: UBUNTU (via SSH)
az vm create \
            --resource-group bademo-vm-cli-rg \
            --name "bademo-linux-cli" \
            --image "UbuntuLTS" \
            --admin-username "turkay" \
            --authentication-type "ssh" \
            --ssh-key-value ~/.ssh/id_rsa.pub \
            --generate-ssh-keys


az vm open-port \
            --resource-group bademo-vm-cli-rg \
            --name "bademo-linux-cli"  \
            --port "22" \

az vm list-ip-addresses \
              --resource-group bademo-vm-cli-rg \
              --name "bademo-linux-cli"  \
              --output table

#azure üzerinden ssh ile Linux makineye bağlan:
ssh turkay@20.107.39.252

#para yazmasın :) RG'leri siliyoruz
az group delete --name bademo-vm-cli-rg --yes --no-wait 