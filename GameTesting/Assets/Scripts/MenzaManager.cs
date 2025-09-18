using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenzaManager : MonoBehaviour
{
    public Dictionary<ItemType, UIItem> UIItems;
    public GameObject MenzaItemPrefab;
    public GameObject MenzaGridObject;
    void Start()
    {
        UIItems = new Dictionary<ItemType, UIItem>
        {
            { ItemType.Pencil, new UIItem(){
                Title = "Kreslíøùv pomocník",
                Subtitle = "Nepøátelé nejsou omalovánky, ale i tak je vybarvíš",
                Description = "Hráè mùže tužku hodit jako projektil. Pokud zasáhne nepøítele, zpùsobí mu poškození. Pokud trefí nepøátelský projektil, obì støely se vzájemnì znièí. Ideální pro obranu proti letícím útokùm a zároveò efektivní zpùsob, jak udržet vzdálenost od nepøátel.",
                UnitPrice = 10,
                Icon = Resources.Load<Sprite>("Sprites/pencilUI")}
            },
            { ItemType.Pearl, new UIItem(){
                Title = "Dimenzionální perla",
                Subtitle = "Nejrychlejší zpùsob, jak zmìnit adresu",
                Description = "Po hodu se hráè okamžitì teleportuje na místo, kam perla dopadne. Umožòuje rychlý únik z nebezpeèí nebo pøekonání pøekážek, ale špatnì zvolený cíl mùže znamenat teleport pøímo do pasti nebo mezi nepøátele.",
                UnitPrice = 25,
                Icon = Resources.Load<Sprite>("Sprites/pearlUI")}
            },
            { ItemType.Hourglass, new UIItem(){
                Title = "Písek èasu",
                Subtitle = "Tak trochu podvádìní, ale koho to zajímá?",
                Description = "Po aktivaci se hráè vrátí pøesnì na místo, kde byl pøed 5 vteøinami. Ideální pro opravu špatných rozhodnutí, útìk z nebezpeèné situace nebo druhý pokus na špatnì provedený skok. Èas se sice vrátí, ale okolí zùstává beze zmìny, takže si dávej pozor, kde resetuješ svou cestu.",
                UnitPrice = 50,
                Icon = Resources.Load<Sprite>("Sprites/hourglassUI")}
            },
            {
                ItemType.Boots, new UIItem(){
                Title = "Bleskoboty",
                Subtitle = "Èas na maraton? Ne, jen utíkáš o život",
                Description = "Po použití se hráè po omezenou pohybuje výraznì rychleji. Zrychlený pohyb usnadòuje vyhýbání se nepøátelským útokùm, rychlé pøesuny po mapì nebo efektivnìjší uniky pøed nebezpeèím. Pozor však na ovládání – vìtší rychlost znamená i horší manévrování v úzkých prostorách.",
                UnitPrice = 15,
                Icon = Resources.Load<Sprite>("Sprites/speedUI")}
            },
            { ItemType.JumpCoil, new UIItem(){
                Title = "Skoková pružina",
                Subtitle = "Kdo potøebuje žebøíky?",
                Description = "Po použití se hráè na omezenou dobu mùže odrážet s vìtší silou, což mu umožní vyskoèit výš než obvykle. Ideální pro dosažení tìžko dostupných míst nebo pøekonání vysokých pøekážek.",
                UnitPrice = 15,
                Icon = Resources.Load<Sprite>("Sprites/coilUI")}
            },
            { ItemType.Binoculars, new UIItem(){
                Title = "Orlí oèi",
                Subtitle = "Najednou vidíš, co nemáš vidìt",
                Description = "Po použití se kamera na omezenou dobu oddálí, což hráèi poskytne širší pohled na okolní prostøedí. Umožòuje lépe plánovat pohyb, odhalit skryté cesty nebo sledovat nepøátele z bezpeèné vzdálenosti.",
                UnitPrice = 30,
                Icon = Resources.Load<Sprite>("Sprites/binocularsUI")}
            },
        };

        foreach(var item in UIItems.Values)
        {
            var shopitem = Instantiate(MenzaItemPrefab, MenzaGridObject.transform);
            shopitem.GetComponent<Image>().sprite = item.Icon;
            shopitem.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("df");
            });
        }
    }
}

public enum ItemType
{
    Pencil,
    Pearl,
    Hourglass,
    Boots,
    JumpCoil,
    Binoculars
}
public class UIItem
{
    public string Title;
    public string Subtitle;
    public string Description;
    public int UnitPrice;
    public Sprite Icon;
}
