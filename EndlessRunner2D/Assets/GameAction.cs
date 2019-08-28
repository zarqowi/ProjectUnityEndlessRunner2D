using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAction : MonoBehaviour
{ 
    public static int MODE_GAME = 0;
    public static string LAGU_PILIHAN ;
    public static int INDEX_PILIHAN = 0;
    public static bool GAME_STATUS = false;
    public static int TRUE_ANS = 0;
    public static int CURR_NOMER = 0;
    public static int TRY_COUNT = 0;
    public static int SCORES = 0;
    public static string TEXT_SOAL = "";
    public static string TEXT_BENAR = "";
    public static List<string> ARRAY_SOAL = new List<string>();
    public static List<string> ARRAY_BENAR = new List<string>();
    public static List<string> KATA_SOAL;
    public static List<string> KATA_JAWAB;
    public static int  GAME_LEVEL = 0;
    public static int[] ITEM_LEVEL = { 1, 2, 3 };
    public static int[] JML_SOAL = { 5, 5, 5 };
    public static string [] JUDUL_LAGU = {"Injit-Injit Semut"
        ,"Gelang Sipaku Gelang"
        ,"Ampar-Ampar Pisang"
        ,"Saputangan Babuncu Ampat"
        ,"Apuse"
        ,"Yamko Rambe Yamko"
        ,"Lir Ilir"
        ,"Cublak Cublak Suweng"
        ,"Ondel-Ondel"
        ,"Dayung Sampan"
        ,"Rasa Sayange"
        ,"Ayo Mama"
        ,"Gunung Salahutu"
        ,"Nani Wartabone" };
    public static string[][] LIRIK_LAGU = {
         new string[] {"Jalan jalan ke tanah deli Sungguh indah tempat tamasya", 
                "Kawan jangan bersedih Mari nyanyi bersama sama Kalau pergi ke surabaya", 
                "Naik prahu dayung sendiri Kalau hatimu sedih", 
                "Ya rugi diri sendiri Injit injit semut", 
                "Siapa sakit naik diatas Injit injit semut ", 
                "Walau sakit jangan dilepas Naik prahu ke pulau sribu", 
                "Sungguh indah sipulau karang Sungguh malang nasibku", 
                "Punya teman diambil orang Ramai sungguh bandar jakarta", 
                "Tempat orang mengikat janji Walau teman tak punya ", 
                "Hati senang dapat bernyanyi Injit injit semut", 
                "Siapa sakit naik diatas Injit injit semut Walau sakit jangan dilepas", },
            new string[] {
                "Gelang sipaku gelang. Gelang si rama-rama Mari pulang Mari-lah pulang. Marilah pulang", 
                "Gelang sipaku gelang. Gelang si rama-rama Mari pulang Mari-lah pulang. Marilah pulang", 
                "Mari pulang Marilah pulang Marilah pulang Bersama-sama Mari pulang Marilah pulang Mari-lah pulang Bersama sama",
            },
             new string[]{"Ampar ampar pisang Pisangku balum masak", 
                "Masak bigi di hurung bari-bari Masak bigi di hurung bari-bari", 
                "Manggalepak manggalepok Patah kayu bengkok", 
                "Bengkok dimakan api apinya cang curupan", 
                "Nang mana batis kutung Dikitipi dawang", 
                "Arti Lagu Ampar-Ampar Pisang Susun-susun pisang", 
                "Pisangku belum masak Masak sebutir dipenuhi bari-bari", 
                "Manggalepak manggalepok Patah kayu yang bengkok", 
                "Yang bengkok dilalap api Apinya hampir padam", 
                "Siapa kaki yang buntung berarti dimakan oleh bidawang"
            },
             new string[]{"Saputangan babuncu ampat Sabuncunya dimakan api", 
                "Dimakan api Luka nang di tangan", 
                "Kawa dibabat Luka nang di hati", 
                "Tabawa mati Tabang bamban jangan diparit", 
                "'Mun diparit buang ka sumur Buang ka sumur", 
                "Rindang pang dandam Jangan diharit", 
                "Lamun diharit Mambawa umur", },
            new string[] {"Apuse kokon dao Yarabe Soren Doreri", 
                "Wuf lenso bani nema baki pase Apuse kokon dao", 
                "Yarabe Soren Doreri Wuf lenso bani nema baki pase", 
                "Arafabye aswarakwar Arafabye aswarakwar", },
            new string[] {"Hee Yamko Rambe Yamko Aronawa Kombe", 
                "Hee Yamko Rambe Yamko Aronawa Kombe", 
                "Temino Kibe Kubano Ko Bombe Ko Yuma No Bungo Awe Ade", 
                "Temino Kibe Kubano Ko Bombe Ko Yuma No Bungo Awe Ade", 
                "Hongke Hongke, Hongke Riro Hongke Jombe, Jombe Riro", 
                "Hongke Hongke, Hongke Riro Hongke Jombe, Jombe Riro"},
            new string[] {"Lir-ilir, lir-ilir, tandure wes sumilir", 
                "Tak ijo royo-royo, tak sengguh temanten anyar", 
                "Cah angon, cah angon, penekno blimbing kuwi", 
                "Lunyu-lunyu penekno kanggo mbasuh dodotiro", 
                "Dodotiro, dodotiro, kumitir bedah ing pinggir", 
                "Dondomono, jlumatono, kanggo sebo mengko sore", 
                "Mumpung pandhang rembulane, mumpung jembar kalangane", 
                "Yo surako surak hiyo" },
            new string[] {"cublak-cublak suweng suwenge ting gelenter", 
                "mampu ketundung gudel pak empo lirak-lirik", 
                "sapa ngguyu ndelikake sir-sir pong dele kopong", 
                "sir-sir pong dele kopong"
                },
            new string[] {"Nyok kita nonton ondel-ondel Nyok", 
                "Nyok kita ngarak ondel-ondel Nyok", 
                "Ondel-ondel ade anaknya nye Boy", 
                "Anaknya ngiger ter iteran Soy", 
                "Mak bapak ondel-ondel ngibing Ser", 
                "Ngarak penganten disunatin Ser", 
                "Goyangnya asik ndut-ndutan Dut", 
                "E nyang ngibing ige-igelan Gel", 
                "Plak dumblang dumblang plak-plak", 
                "Gendang nyaring ditepak Yang ngiringin nandak", 
                "Pade surak-surak Tangan iseng jailin", 
                "Kepale anak ondel-ondel Taroin puntungan", 
                "Rambut kebakaran Anak ondel-ondel jijikrakan Krak", 
                "Kepale nyale berkobaran  Bul", 
                "Yang ngarak pada kebingungan Ngung", 
                "Disiramin air cecomberan Byur", },
             new string[]{"Dayung sampan mencari ikan ikan dicari hai nelayan di tengah muara", 
                "Kalau tuan mencari makan cari makan jual suara menjual suara", 
                "Lay lay la la la la lay menjual suara lay lay lay", 
                "lay lay lay lay lay lay lay lay lay ", 
                "Dayung dayung dayung dayung dayung sampan", 
                "Dayung sampan sampan didayung sampan didayung hai nelayang ke tengah lautan", 
                "Kalau tuan mencari jodoh jangan mencari hai nalayan hai nelayan Lay lay", 
                "Lay lay la la la la lay hai nelayan lay lay lay", 
                "lay lay lay lay lay lay lay lay lay", 
                "Dayung dayung dayung dayung dayung sampan "},
           new string[]  {"Rasa sayange rasa sayang sayange", 
                "Kulihat dari jauh rasa sayang sayange", 
                "Rasa sayange rasa sayang sayange Kulihat dari jauh rasa sayang sayange", 
                "Jalan jalan kekota paris Lihat gedung berbaris baris", 
                "Anak manis jangan menangis Kalau menangis malah meringis", 
                "Rasa sayange rasa sayang sayange Kulihat dari jauh rasa sayang sayange", 
                "Rasa sayange rasa sayang sayange Kulihat dari jauh rasa sayang sayange", 
                "Sana belang disini belang Anak kucingku yang manis", 
                "Sana senang disini senang Ayo kita menyanyi lagi", 
                "Rasa sayange rasa sayang sayange Kulihat dari jauh rasa sayang sayange", 
                "Rasa sayange rasa sayang sayange Kulihat dari jauh rasa sayang sayange",  },
            new string[] {"Ayo mama jangan mama marah beta", 
                "Dia cuma dia cuma pegang beta", 
                "Ayo mama jangan mama marah beta", 
                "Lah orang muda punya biasa", 
                "Ayam hitam telurnya putih", 
                "Mencari makan di pinggir kali", 
                "Sinyo hitam giginya putih", 
                "Kalau ketawa manis sekali", 
                "Ayo mama jangan mama marah beta", 
                "Dia cuma dia cuma pegang beta", 
                "Ayo mama jangan mama marah beta", 
                "Lah orang muda punya biasa", 
                "Lembe-lembe makan ketupat", 
                "Kondo bujang di air mangir", 
                "Mambu reweh mau bersumpah", 
                "Lah ingat bujang terlalu manis", 
                "Ayo mama jangan mama marah beta", 
                "Dia cuma dia cuma pegang beta", 
                "Ayo mama jangan mama marah beta", 
                "Lah orang muda punya biasa",  },
            new string[] {"Kota Ambon ibu negeri tanah Maluku", 
                "Di pinggir laut tempat kita bersatu", 
                "Dari jauh terlihat Gunung Salahutu", 
                "Beta ingat dahulu beta di situ", 
                "Bulan terang menerangi tepian pantai", 
                "Bunyi gitar suara tifa beramai-ramai", 
                "Sio Ambon dengan teluk yang indah permai", 
                "Apa tempo beta lihat engkau lagi",  },
            new string[] {"Ti pa' Nani Wartabone", 
                "donggo boli buheli liyo", 
                "Lo la wani kumbani ya Japangi waw", 
                "Permesta lolo lopu moa amila",  
                "Di yalu ta ohe liyo", 
                "penu bulo bulo tahiyo", 
                "Ambao dudula liyo gaso mota pu liyo", 
                "u i tolo a kali liyo",  
                "Masa tiya ma amani lipu ma ilo di", 
                "huma bolo mo po'o daha pi lito", 
                "Sambe duhu u mo pu lito ho", 
                "ho ho ho ho ho ho ho",  
                "Tipa' Nani Wartabone", 
                "lolo ta tanggulo mopiyo", 
                "Dudui lo pongotota ili mu po'o dapata", 
                "tilangiyo lo lipu ta uwa",  }, 

    }; 

    public  void pilih_LAGU(int indexJudul){
        
        resetSetting();
        INDEX_PILIHAN = indexJudul;
        LAGU_PILIHAN = JUDUL_LAGU[indexJudul];
        Debug.Log(JUDUL_LAGU[indexJudul]);
    } 
    public void pilihMode(int Mode){
        GameAction.MODE_GAME = Mode;
        GameAction.SCORES = 0;
        
        resetSetting();
    }

    public static void resetSetting(){
        GameAction.LAGU_PILIHAN = "";
        GameAction.TRUE_ANS = 0;
        GameAction.CURR_NOMER = 0;
        GameAction.TRY_COUNT = 0;
    }
    public void setLevel(int Level){ 
        resetSetting();
        GameAction.GAME_LEVEL = Level;
        GameAction.SCORES = 0;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
