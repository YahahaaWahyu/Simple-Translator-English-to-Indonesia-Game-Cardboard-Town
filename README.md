# 🃏 TRtoINA — Mod Terjemahan Cardboard Town (Bahasa Indonesia)

Mod BepInEx untuk game **Cardboard Town** yang menerjemahkan seluruh antarmuka, kartu, event, bencana, tips, dan teks lainnya dari **Bahasa Inggris** ke **Bahasa Indonesia** secara otomatis saat runtime.

---

## 📋 Daftar Isi
- [Alat dan Bahan](#-alat-dan-bahan)
- [Cara Kerja Mod](#-cara-kerja-mod)
- [Cara Build dari Source Code](#-cara-build-dari-source-code)
- [Cara Pemasangan Mod](#-cara-pemasangan-mod)
- [Menambah atau Memperbaiki Terjemahan](#-menambah-atau-memperbaiki-terjemahan)
- [Troubleshooting](#-troubleshooting)

---

## 🛠️ Alat dan Bahan

### Wajib (untuk pengguna mod):
| Alat | Keterangan | Link |
|------|-----------|------|
| **Cardboard Town** | Game yang dimod (versi Steam) | [Steam](https://store.steampowered.com/app/1740680/Cardboard_Town/) |
| **BepInEx 5.x** (x64) | Framework mod loader untuk game Unity | [Download](https://github.com/BepInEx/BepInEx/releases) |
| **TRtoINA.dll** | File mod hasil build | Dari [Releases](../../releases) |
| **translation.json** | File kamus terjemahan | Dari [Releases](../../releases) |

### Tambahan (untuk developer / build sendiri):
| Alat | Keterangan | Link |
|------|-----------|------|
| **.NET SDK 6+** | Untuk compile source code | [Download](https://dotnet.microsoft.com/download) |
| **Visual Studio / VS Code** | Editor kode (opsional) | [VS Code](https://code.visualstudio.com/) |

---

## ⚙️ Cara Kerja Mod

Mod ini bekerja menggunakan **Harmony Patcher** yang dipasang oleh BepInEx. Cara kerjanya:

```
Game Berjalan
     │
     ▼
Komponen Teks Muncul di Layar
(TextMeshPro / UI.Text)
     │
     ▼
Harmony mengintersepsi setter .text
     │
     ▼
Translator.Translate(teks) dipanggil
     │
     ├─ [ADA di translation.json] ──► Teks langsung diganti ke Bahasa Indonesia ✅
     │
     └─ [TIDAK ADA di translation.json]
              │
              ▼
         Teks dicatat ke missing.json
         (untuk diterjemahkan di versi berikutnya)
```

### Komponen Utama:

| File | Fungsi |
|------|--------|
| `IndonesiaMod.cs` | Plugin utama BepInEx, titik masuk mod |
| `TranslationDatabase.cs` | Memuat `translation.json` dan mengelola `missing.json` |
| `Translator.cs` | Mesin pencarian dan penggantian terjemahan |
| `UIPatch.cs` | Mengintersepsi semua komponen teks UI di game |
| `DeckManagerPatch.cs` | Menerjemahkan judul & deskripsi kartu saat game dimuat |
| `DescriptionPatch.cs` | Menerjemahkan deskripsi kartu saat ditampilkan |
| `SimpleJsonDictionary.cs` | Parser JSON custom yang ringan dan cepat |

---

## 🔨 Cara Build dari Source Code

> Lewati bagian ini jika kamu hanya ingin **memasang mod** (bukan develop). Gunakan file dari [Releases](../../releases).

### 1. Clone repositori ini
```bash
git clone https://github.com/YahahaaWahyu/Simple-Translator-English-to-Indonesia-Game-Cardboard-Town.git
cd Simple-Translator-English-to-Indonesia-Game-Cardboard-Town
```

### 2. ⚠️ Sesuaikan Path di TRtoINA.csproj — PENTING!

> [!IMPORTANT]
> Buka file `TRtoINA.csproj` dan **ubah semua path** agar sesuai dengan lokasi instalasi game di komputermu.

**Path default di file ini menggunakan drive `D:` (SteamLibrary kustom).**
Kebanyakan pengguna Steam menginstal game di drive `C:`, sehingga path perlu disesuaikan.

**Contoh path default (harus diubah jika berbeda):**
```xml
<HintPath>D:\SteamLibrary\steamapps\common\Cardboard Town\BepInEx\core\BepInEx.dll</HintPath>
```

**Ubah sesuai lokasi game kamu. Kemungkinan lokasi Steam yang umum:**

| Skenario | Path |
|----------|------|
| Steam default di `C:` | `C:\Program Files (x86)\Steam\steamapps\common\Cardboard Town\` |
| Steam Library kustom di `D:` | `D:\SteamLibrary\steamapps\common\Cardboard Town\` |
| Steam Library kustom di `E:` | `E:\SteamLibrary\steamapps\common\Cardboard Town\` |

**Cara cek lokasi game kamu di Steam:**
1. Buka Steam → Library → klik kanan **Cardboard Town**
2. Pilih **Properties** → **Local Files** → **Browse...**
3. Salin path dari address bar File Explorer

Ganti semua baris `<HintPath>` di `TRtoINA.csproj` dengan path yang sesuai. Ada **6 referensi** yang perlu diganti:
```xml
<!-- Ganti D:\SteamLibrary dengan path game kamu -->
<HintPath>PATHGAMEMU\BepInEx\core\BepInEx.dll</HintPath>
<HintPath>PATHGAMEMU\BepInEx\core\0Harmony.dll</HintPath>
<HintPath>PATHGAMEMU\card-board-town_Data\Managed\Assembly-CSharp.dll</HintPath>
<HintPath>PATHGAMEMU\card-board-town_Data\Managed\UnityEngine.dll</HintPath>
<HintPath>PATHGAMEMU\card-board-town_Data\Managed\UnityEngine.CoreModule.dll</HintPath>
<HintPath>PATHGAMEMU\card-board-town_Data\Managed\Unity.TextMeshPro.dll</HintPath>
<HintPath>PATHGAMEMU\card-board-town_Data\Managed\UnityEngine.UI.dll</HintPath>
```

### 3. Build proyek
```bash
dotnet build
```

File hasil build ada di: `bin\Debug\net472\TRtoINA.dll`

---

## 📦 Cara Pemasangan Mod

> [!TIP]
> Cara termudah: Download file ZIP dari [Releases](../../releases) dan ekstrak langsung ke folder game.

### Langkah 1 — Install BepInEx
1. Download **BepInEx 5.x (x64)** dari [link ini](https://github.com/BepInEx/BepInEx/releases).
2. Ekstrak isi ZIP ke dalam folder game Cardboard Town.

**Folder game Cardboard Town biasanya ada di:**
```
C:\Program Files (x86)\Steam\steamapps\common\Cardboard Town\
```
*(Sesuaikan dengan lokasi Steam Library kamu)*

Setelah ekstrak, struktur folder akan menjadi:
```
Cardboard Town\
├── BepInEx\          ← hasil ekstrak BepInEx
├── card-board-town.exe
└── ...
```
3. Jalankan game sekali agar BepInEx melakukan setup awal, lalu **tutup game**.

### Langkah 2 — Install Mod TRtoINA
1. Buat folder baru:
   ```
   Cardboard Town\BepInEx\plugins\TRtoINA\
   ```
2. Download file dari [Releases](../../releases), kemudian salin ke dalam folder tersebut:
   - `TRtoINA.dll`
   - `translation.json`

### Langkah 3 — Jalankan Game
Buka Cardboard Town melalui Steam. Jika mod berjalan dengan benar, teks di dalam game akan tampil dalam **Bahasa Indonesia**!

### ✅ Struktur akhir yang benar:
```
Cardboard Town\
└── BepInEx\
    └── plugins\
        └── TRtoINA\
            ├── TRtoINA.dll       ← file mod
            ├── translation.json  ← kamus terjemahan
            └── missing.json      ← dibuat otomatis oleh mod
```

> [!WARNING]
> **Jangan** taruh `TRtoINA.dll` langsung di folder `plugins\` (tanpa subfolder `TRtoINA\`). Ini akan membuat mod berjalan dua kali dan menyebabkan bug duplikat terjemahan!

---

## 📝 Menambah atau Memperbaiki Terjemahan

File `translation.json` adalah kamus sederhana berformat:
```json
{
  "Teks Inggris": "Terjemahan Indonesia",
  "Fire Station": "Stasiun Pemadam Kebakaran",
  "Gain +1 #Safety.": "Dapatkan +1 #Safety."
}
```

### Cara menambah terjemahan baru:
1. Buka file `translation.json` di folder plugin.
2. Tambahkan baris baru di dalam kurung kurawal `{}`.
3. Simpan file, lalu **restart game** — perubahan langsung berlaku tanpa perlu build ulang!

### Teks yang belum terjemahkan:
Setiap teks yang belum ada di `translation.json` akan **dicatat otomatis** ke file `missing.json`. Kamu bisa membuka file ini untuk melihat teks apa saja yang perlu diterjemahkan.

---

## 🐛 Troubleshooting

| Masalah | Solusi |
|---------|--------|
| Teks masih Bahasa Inggris | Pastikan `TRtoINA.dll` dan `translation.json` ada di folder `plugins\TRtoINA\` |
| Teks muncul setengah-setengah | Buka `missing.json` dan tambahkan terjemahan kalimat penuhnya ke `translation.json` |
| Game crash saat start | Pastikan versi BepInEx yang digunakan adalah **5.x (x64)** |
| Mod berjalan ganda / terjemahan duplikat | Hapus `TRtoINA.dll` yang ada langsung di folder `plugins\` (bukan di subfolder) |
| Error saat build: path tidak ditemukan | Sesuaikan path di `TRtoINA.csproj` dengan lokasi game di komputermu |
| `missing.json` tidak terbuat | Pastikan folder `plugins\TRtoINA\` sudah ada sebelum menjalankan game |

---

## 📄 Lisensi

Proyek ini bersifat open-source dan dibuat untuk keperluan komunitas modding Indonesia.  
Game Cardboard Town adalah milik dari **Stratera Games**.
