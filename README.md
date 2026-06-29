# TRtoINA - Cardboard Town Indonesian Translation Mod

Mod terjemahan Bahasa Indonesia untuk game **Cardboard Town** menggunakan framework **BepInEx** dan **Harmony**.

## 🚀 Fitur Utama
- **Terjemahan UI Universal**: Menerjemahkan komponen `TextMeshPro` dan `UI.Text` secara dinamis di seluruh tampilan game (Menu Utama, Pengaturan, Event, Popup, Tutorial, Bencana, dll).
- **Penerjemah Kartu**: Menerjemahkan judul dan deskripsi kartu bangunan, kartu aksi, dan kartu bencana.
- **Pencatat Otomatis (Auto-Capture)**: Jika ada teks baru yang belum terdaftar di kamus, mod secara otomatis mencatatnya ke `missing.json` agar mudah ditambahkan.
- **Ringan & Cepat**: Menggunakan kamus parser JSON khusus berkinerja tinggi tanpa dependensi eksternal berat.

## 🛠️ Struktur Proyek
- `IndonesiaMod.cs` - Plugin utama BepInEx & inisialisasi Harmony Patcher.
- `TranslationDatabase.cs` - Pengelola muatan kamus `translation.json` dan perekam `missing.json`.
- `Translator.cs` - Mesin translasi pencocokan kalimat dan kata.
- `UIPatch.cs` - Interceptor universal untuk objek komponen `TMP_Text` dan `Text`.
- `DeckManagerPatch.cs` & `DescriptionPatch.cs` - Hook untuk komponen kartu in-game.
- `SimpleJsonDictionary.cs` - Parser JSON kustom untuk penanganan dictionary.

## 📥 Cara Pemasangan Mod
1. Pastikan **BepInEx 5** sudah terinstall pada folder game Cardboard Town kamu.
2. Compile proyek ini untuk mendapatkan DLL (`TRtoINA.dll`).
3. Letakkan `TRtoINA.dll` dan file kamus `translation.json` di folder:
   `Cardboard Town\BepInEx\plugins\TRtoINA\`
4. Jalankan game dan nikmati bermain dalam Bahasa Indonesia!

## 📜 Lisensi
Dikembangkan untuk komunitas Modding Indonesia Cardboard Town.
