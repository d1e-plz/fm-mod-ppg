using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

namespace Mod
{
    public class Mod
    {
public static string item = "<color=purple>item <color=white>";
public static string ModTag = "<color=purple>FM <color=white>";
        public static void Main()
        {
CategoryBuilder.Create("FM", "Mod for fun and fun!", ModAPI.LoadSprite("other_sprites/category icon.png"));
CategoryBuilder.Create("FM Accs", "", ModAPI.LoadSprite("other_sprites/category icon.png"));

//Unity блять Engine https://docs.unity3d.com/2020.1/Documentation/Manual/index.html
//Methods что то выполняет в большенстве случеев не требует присваивания информации
//Properties можно лишь присвоить этому типу информацию
//Fields могут принимать знаения или присваивать
//ModAPI https://www.studiominus.nl/ppg-modding/internalReference/ModAPI.html
//PersonBehaviour https://www.studiominus.nl/ppg-modding/internalReference/PersonBehaviour.html
//создание предметов и кастомные люди лол... https://www.studiominus.nl/ppg-modding/tutorials/tutorialCustomItem.html и https://www.studiominus.nl/ppg-modding/snippets/customHuman.html

//Сложный вариант (ТОЕСТЬ ОБЫЧНЫЙ.) с волосами
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"), //рекомендую использовать Human, Android и Rod
        NameOverride = ModTag + "ded", //Имя обьекта
        DescriptionOverride = "OH MY GOD ", //Описание обьекта
        CategoryOverride = ModAPI.FindCategory("FM"), //категория не трогать
        ThumbnailOverride = ModAPI.LoadSprite("persons/ded/53.png"), //Иконка обьекта
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>(); //https://www.studiominus.nl/ppg-modding/internalReference/PersonBehaviour.html 

            var Head = Instance.transform.GetChild(5);//бошка
	        var skin = ModAPI.LoadTexture("persons/ded/ded.png"); //1 слой Human или Android
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");//2 слой
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");//3 слой
            var childObject = new GameObject("hairs"); //Новый игровой обьект
            childObject.transform.SetParent(Head); //Задаёт родителя
            childObject.transform.localPosition = new Vector3(0f, 0f); //положение относительно 0 (если с первого раза не попадешь...)
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);//1 и 2 х полное, 3 поворот в градусах
            childObject.transform.localScale = new Vector3(1f, 1f);//размер относительно 1
            var childSprite = childObject.AddComponent<SpriteRenderer>();//компонент спрайт рендер
            childSprite.sprite = ModAPI.LoadSprite("persons/ded/Hair_Female_8.png");//текстура игрового обьекта, конец создания (ОТСУСТВУЕТ КОЛИЗИЯ И Т.Д. Т.К. new GameObject подрозумевает полностью пустую оболчку)

            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName; //устоналивает сортировачный слой тот что и у обьекта в переменной
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1; //+1 к слою (поверх указаного выше обьекта)
	    person.Limbs[10].transform.localScale = new Vector3(1.2f, 1f);
        person.Limbs[11].transform.localScale = new Vector3(1f, 0.95f);
        person.Limbs[11].transform.localPosition = new Vector3(0f, -0.5f);
        person.Limbs[12].transform.localScale = new Vector3(1.2f, 1f);
        person.Limbs[13].transform.localScale = new Vector3(1f, 0.95f);
        person.Limbs[13].transform.localPosition = new Vector3(0f, -0.5f);
            


            person.SetBodyTextures(skin, flesh, bone, 1); //устонавливает 1, 2 и 3 слой, последний int отвечает за размер текстуры
        }
    }
);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag + "Vova",
        DescriptionOverride = "ok...just russian name. It's so stupid ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/vova1/icn.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	    var skin = ModAPI.LoadTexture("persons/vova1/loh.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");	

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(0f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1.02f, 1.02f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = ModAPI.LoadSprite("persons/vova1/hat.png");

            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
	    

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
);         
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag + "Larekvovaak2",
        DescriptionOverride = "I.. The new Larekvova.  ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/vova3/icn.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	        var skin = ModAPI.LoadTexture("persons/vova3/skin.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");	
            var arm1 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
            var lowerBody = Instance.transform.Find("Body").Find("LowerBody");
            var leg = Instance.transform.Find("FrontLeg").Find("UpperLegFront");

            var childObject1 = new GameObject("hairs");
            childObject1.transform.SetParent(Head);
            childObject1.transform.localPosition = new Vector3(0.0286f, 0.05f); 
            childObject1.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            childObject1.transform.localScale = new Vector3(1f, 1f);
            var childSprite1 = childObject1.AddComponent<SpriteRenderer>();
            childSprite1.sprite = ModAPI.LoadSprite("persons/vova3/hat.png");

            childSprite1.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite1.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
	    

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag + "alt D1e_plz",
        DescriptionOverride = "Why.  dev",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/alt_d1e/icn.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	        var skin = ModAPI.LoadTexture("persons/L1fe/D1e_plz.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");	
            var arm1 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
            var lowerBody = Instance.transform.Find("Body").Find("LowerBody");
            var leg = Instance.transform.Find("FrontLeg").Find("UpperLegFront");

            var childObject1 = new GameObject("hairs");
            childObject1.transform.SetParent(Head);
            childObject1.transform.localPosition = new Vector3(0f, 0f); 
            childObject1.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            childObject1.transform.localScale = new Vector3(1.03f, 1.03f);
            var childSprite1 = childObject1.AddComponent<SpriteRenderer>();
            childSprite1.sprite = ModAPI.LoadSprite("persons/alt_d1e/hat.png");

            childSprite1.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite1.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 2;
	        Head.GetComponent<SpriteRenderer>().sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder - 1;
	    

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag + "alt L1fe_plz",
        DescriptionOverride = "bebrachka \n Interact with head to turn of the mask ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/alt_L1fe/icn.png"),
        AfterSpawn = (Instance) =>
        {
            var person = Instance.GetComponent<PersonBehaviour>();
            for(int i = 0; i < 14; i++)
            {
                person.Limbs[i].SpeciesIdentity = "Android";
                person.Limbs[i].BloodLiquidType = "OIL";
                person.Limbs[i].ImpactPainMultiplier = 0f;
                person.Limbs[i].ShotDamageMultiplier = 0.1f;
                person.Limbs[i].ImpactDamageMultiplier = 0.1f;
            };
                var Head = Instance.transform.GetChild(5); 
	        var skin = ModAPI.LoadTexture("persons/alt_L1fe/d1e.png");
            var flesh = ModAPI.LoadTexture("persons/alt_L1fe/flesh.png");
            var bone = ModAPI.LoadTexture("persons/alt_L1fe/bone.png");
            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(-0.04f, -0.03f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1.06f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = ModAPI.LoadSprite("persons/alt_L1fe/hair.png");
            var childObject1 = new GameObject("hairs1");
            childObject1.transform.SetParent(Head);
            childObject1.transform.localPosition = new Vector3(0.0005f, 0.04f);
            childObject1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject1.transform.localScale = new Vector3(1.13f, 1.13f);
            var childSprite1 = childObject1.AddComponent<SpriteRenderer>();
            childSprite1.sprite = ModAPI.LoadSprite("persons/alt_L1fe/mask.png");
            var childObject2 = new GameObject("hairs1");
            childObject2.transform.SetParent(person.Limbs[1].transform);
            person.Limbs[2].transform.localScale = new Vector3(0.96f, 1f);
            childObject2.transform.localPosition = new Vector3(0.003f, -0.029f);
            childObject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject2.transform.localScale = new Vector3(1f, 1.02f);
            var childSprite2 = childObject2.AddComponent<SpriteRenderer>();
            childSprite2.sprite = ModAPI.LoadSprite("persons/alt_L1fe/tors.png");

            childSprite2.sortingLayerName = person.Limbs[1].GetComponent<SpriteRenderer>().sortingLayerName;
            person.Limbs[2].GetComponent<SpriteRenderer>().sortingOrder = person.Limbs[3].GetComponent<SpriteRenderer>().sortingOrder - 1;
	        childSprite2.sortingOrder = person.Limbs[1].GetComponent<SpriteRenderer>().sortingOrder + 1;
            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
            childSprite1.sortingLayerName = childSprite.GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite1.sortingOrder = childSprite.GetComponent<SpriteRenderer>().sortingOrder - 1;
            Head.GetComponent<SpriteRenderer>().sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
            Head.GetComponent<SpriteRenderer>().sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder - 1;
            Material mat = childSprite1.GetComponent<Renderer>().material;
            Color color = mat.color;
            color.a = 0.87f;
            mat.color = color;
            var glow = ModAPI.CreateLight(childObject1.transform, Color.red, 5, 1);
            glow.transform.localScale = new Vector3(1.5f,0.6f);
            bool use = true;
            Head.gameObject.AddComponent<UseEventTrigger>().Action = () =>
            {
                if(use==false)
                {
                    glow.Brightness = 1;
                    use = true;
                    ModAPI.CreateParticleEffect("Vapor",childObject1.transform.position);
                    childObject1.transform.localScale = new Vector3(1.13f, 1.13f);
                }
                else
                {   
                    glow.Brightness = 0;
                    use = false;
                    ModAPI.CreateParticleEffect("FuseBlown",childObject1.transform.position);
                    childObject1.transform.localScale = new Vector3(0f, 0f);
                };
            };
                person.SetBodyTextures(skin, flesh, bone, 1);
       }
    }
);        

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag +"Just R3lax",
        DescriptionOverride = "This is also a developer. uh.. He's lazy.\n open context menu in torso to summon Crimson Relax  dev",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/Relax/3.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	        var skin = ModAPI.LoadTexture("persons/Relax/Just_R3lax.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");
            var hair = ModAPI.LoadSprite("persons/Relax/Hair_Female_1.png");
            var MiddleBody = Instance.transform.Find("Body").Find("MiddleBody");	
            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(0f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = hair;

            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;

            person.SetBodyTextures(skin, flesh, bone, 1);
            var skin2 = ModAPI.LoadTexture("persons/C_Relax/Crimson_r3lax.png");
            var hair2 = ModAPI.LoadSprite("persons/C_Relax/Hair_Female_6.png");
            bool use = false;
            //гайд на контекст меню ПРОШУ НЕ СОВЕРШАЙ МОЕЙ ОШИБКИ И НЕ КОПИРУЙ ПОМЕТКУ.
            //ниже строки копируешь до следуйщей пометки
            for(int i = 0; i < 14; i++)
            {
            person.Limbs[i].GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("change skin", "Change skin", "Change skin for Just R3lax.", new UnityAction[]
            {
                (UnityAction) (() =>
                {
                    if(use==false)
                    {
                        childSprite.sprite = hair2;
                        person.SetBodyTextures(skin2, flesh, bone, 1);
                        use = true;
                        ModAPI.CreateParticleEffect("BrokenElectronicsSpark",MiddleBody.transform.position);
                    }
                    else
                    {
                        childSprite.sprite = hair;
                        person.SetBodyTextures(skin, flesh, bone, 1);
                        use = false;
                        ModAPI.CreateParticleEffect("BrokenElectronicsSpark",MiddleBody.transform.position);
                    };
                })
                
            }));};
            //До сюда
            //в данном ЮНИТИ ИВЕНТЕ БЛЯТЬ есть 5 переменные hair/hair2 skin/skin2 и use
            // use принимает false и true он отслеживает какой сейчас скин
            // hair - 1 волосы (которые даются при спавне) их НУЖНО записать в var hair = ModAPI.LoadSprite("тут путь к волосам")
            // hair2 - 2 волосы (которые заменяют первые) принцип тот же только  var hair2 = ModAPI.LoadSprite("тут путь к вторым волосам")
            // у skin и skin2 принцип тот же соотвествено нужно заменить название перемменой на skin и skin2
            //так же к волосам идет childSprite это твои волосы
            //ModAPIC.CreateParticleEffect(string,gameObject.transform.position) это частицы после нажатия в контекст меню кнопки
            //НЕ ТРОГАЙ кроме string https://www.studiominus.nl/ppg-modding/snippets/particles.html там все частицы записывай в кавычках ""
            //НЕ МЕНЯЙ IF И ELSE ЕСЛИ НУЖЕН ФАКТОР ELIF(3 вариант) ИСПОЛЬЗУЙ ELSE IF (А ЛУЧШЕ МЕНЯ ЗОВИ!!!)
            //НЕ ТРОГАЙ СТРОКУ (UnityAction) (() =>
            //в самом начале Instance.transform.Find("Body").Find("UpperBody").GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton и т.д.
            //в new ContextMenuButton("нечего в игре не меняет", "имя", "описание", new UnityAction[] и дальше само действие
            // по желанию можно убрать if строки и сделать не логическое действие (например поменять скин в одну сторону или создать партикал)
            
        }
    }
);      

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag + "Just Gr3en",
        DescriptionOverride = "he just green \n it's just r3lax ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/t._relax/190.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>(); 
            var Head = Instance.transform.GetChild(5);
	        var skin = ModAPI.LoadTexture("persons/t._relax/Just_Green.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");	

            var childObject2 = new GameObject("hairs2");
            childObject2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
            childObject2.transform.localPosition = new Vector3(-0.07f, 0.02f);
            childObject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            childObject2.transform.localScale = new Vector3(1f, 1f);
            var childSprite2 = childObject2.AddComponent<SpriteRenderer>();
            childSprite2.sprite = ModAPI.LoadSprite("persons/t._relax/b1.png");

            var childObject3 = new GameObject("hairs3");
            childObject3.transform.SetParent(Instance.transform.Find("Body").Find("MiddleBody"));
            childObject3.transform.localPosition = new Vector3(0.017f, -0.02f);
            childObject3.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            childObject3.transform.localScale = new Vector3(1f, 1f);
            var childSprite3 = childObject3.AddComponent<SpriteRenderer>();
            childSprite3.sprite = ModAPI.LoadSprite("persons/t._relax/b2.png");

            var childObject4 = new GameObject("hairs4");
            childObject4.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
            childObject4.transform.localPosition = new Vector3(-0.01f, -0.007f);
            childObject4.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            childObject4.transform.localScale = new Vector3(1f, 1f);
            var childSprite4 = childObject4.AddComponent<SpriteRenderer>();
            childSprite4.sprite = ModAPI.LoadSprite("persons/t._relax/b3.png");

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(-0.02f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = ModAPI.LoadSprite("persons/t._relax/Hair_Female_2.png");

            childSprite4.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite4.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
            childSprite3.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite3.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 2;
            childSprite2.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite2.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag + "LarekVova",
        DescriptionOverride = "he just copy toxic, but red ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/vova2/4.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	    var skin = ModAPI.LoadTexture("persons/vova2/pidor.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");	

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(-0.07f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = ModAPI.LoadSprite("persons/vova2/Hair_Male_1.png");

            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
	    

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
);         

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag + "sds",
        DescriptionOverride = "don't ask me... ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/sds/sdsicn.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	    var skin = ModAPI.LoadTexture("persons/sds/sds.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");	

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(0f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = ModAPI.LoadSprite("persons/sds/sdshair.png");

            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
	    

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
);   



ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag +"sasarabhyn",
        DescriptionOverride = "oh sh.. ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/s1/302.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	        var skin = ModAPI.LoadTexture("persons/s1/sasarabhyn1.png");
            var skin2 = ModAPI.LoadTexture("persons/s2/sasarabhyn2.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");
            var MiddleBody = Instance.transform.Find("Body").Find("MiddleBody");	

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(0f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = ModAPI.LoadSprite("persons/s1/Hair_Male_6.png");

            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
        bool use = false;
        for(int i = 0; i < 14; i++)
        {
	    person.Limbs[i].GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("change skin", "Change skin", "Change skin for motaevmaxx.", new UnityAction[]
            {
                (UnityAction) (() =>
                {
                    if(use==false)
                    {
                        childObject.transform.localScale = new Vector3(0f, 0f);
                        person.SetBodyTextures(skin2, flesh, bone, 1);
                        use = true;
                        ModAPI.CreateParticleEffect("BrokenElectronicsSpark",MiddleBody.transform.position);
                    }
                    else
                    {
                        childObject.transform.localScale = new Vector3(1f, 1f);
                        person.SetBodyTextures(skin, flesh, bone, 1);
                        use = false;
                        ModAPI.CreateParticleEffect("BrokenElectronicsSpark",MiddleBody.transform.position);
                    };
                })
                
            }));};

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
);  



ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag + "motaevmaxx",
        DescriptionOverride = "TI SACHEM CIEL MOI CHOCO-PIE!? ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/m2/4354.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	        var skin2 = ModAPI.LoadTexture("persons/m1/motaevmaxx1.png");
            var skin = ModAPI.LoadTexture("persons/m2/motaevmaxx2.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");
            var hair2 = ModAPI.LoadSprite("persons/m1/Hair_Male_3.png");
            var hair = ModAPI.LoadSprite("persons/m2/Hair_Male_2.png");
            var MiddleBody = Instance.transform.Find("Body").Find("MiddleBody");

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(0f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = hair;
            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
	    bool use = false;
        for(int i = 0; i < 14; i++)
        {
        person.Limbs[i].GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("change skin", "Change skin", "Change skin for motaevmaxx.", new UnityAction[]
            {
                (UnityAction) (() =>
                {
                    if(use==false)
                    {
                        childSprite.sprite = hair2;
                        person.SetBodyTextures(skin2, flesh, bone, 1);
                        use = true;
                        ModAPI.CreateParticleEffect("BrokenElectronicsSpark",MiddleBody.transform.position);
                    }
                    else
                    {
                        childSprite.sprite = hair;
                        person.SetBodyTextures(skin, flesh, bone, 1);
                        use = false;
                        ModAPI.CreateParticleEffect("BrokenElectronicsSpark",MiddleBody.transform.position);
                    };
                })
                
            }));};
            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
); 

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag +"D1e_plz",
        DescriptionOverride = "WOMANN!!! \n oh..it's D1e_plz? or L1fe_plz idk XD ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/D1e/d1eicon.png"),
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var UpperBody = Instance.GetComponent<PersonBehaviour>().Limbs[1].transform;
            var Head = Instance.transform.GetChild(5);
	    var skin = ModAPI.LoadTexture("persons/D1e/d1e.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");	

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(0f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
	    childSprite.sprite = ModAPI.LoadSprite("persons/D1e/hair.png");
	            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
	    

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
); 

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag +"Just Upgrade",
        DescriptionOverride = "Ok, he is black.\n Press on the torso to activate the blade ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/JustUpg/3.png"),
        AfterSpawn = (Instance) =>
        {


	        var person = Instance.GetComponent<PersonBehaviour>();
	        var skin = ModAPI.LoadTexture("persons/JustUpg/UpgradeR3lax.png");
            var skin2 = ModAPI.LoadTexture("persons/JustUpg/UpgradeR3lax2.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");
            person.SetBodyTextures(skin, flesh, bone, 1);
            var Head = Instance.transform.GetChild(5);
	    	var properties = ModAPI.FindPhysicalProperties("Weapon");
            	properties.Sharp = true;
            	properties.SharpAxes = new SharpAxis[]
                        {
                            new SharpAxis(Vector2.up, 0f, 1f, true, true),
                     	};
            var someobject2 = ModAPI.CreatePhysicalObject("blade", ModAPI.LoadSprite("persons/JustUpg/blade.png"));
            var somesprite2 = someobject2.GetComponent<SpriteRenderer>();

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(person.Limbs[0].transform);
            childObject.transform.localPosition = new Vector3(0f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = ModAPI.LoadSprite("persons/JustUpg/Hair_Female_1.png");
            var childObject2 = new GameObject("hairs2");
            childObject2.transform.SetParent(person.Limbs[1].transform);
            childObject2.transform.localPosition = new Vector3(-0.05f, 0.02f);
            childObject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            childObject2.transform.localScale = new Vector3(1f, 1f);
            var childSprite2 = childObject2.AddComponent<SpriteRenderer>();
            childSprite2.sprite = ModAPI.LoadSprite("persons/JustUpg/b1.png");
            var childObject3 = new GameObject("hairs3");
            childObject3.transform.SetParent(person.Limbs[2].transform);
            childObject3.transform.localPosition = new Vector3(-0.05f, 0.02f);
            childObject3.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            childObject3.transform.localScale = new Vector3(1f, 1f);
            var childSprite3 = childObject3.AddComponent<SpriteRenderer>();
            childSprite3.sprite = ModAPI.LoadSprite("persons/JustUpg/b2.png");
            var childObject4 = new GameObject("hairs4");
            childObject4.transform.SetParent(person.Limbs[3].transform);
            childObject4.transform.localPosition = new Vector3(-0.05f, -0.1f);
            childObject4.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            childObject4.transform.localScale = new Vector3(1f, 1f);
            var childSprite4 = childObject4.AddComponent<SpriteRenderer>();
            childSprite4.sprite = ModAPI.LoadSprite("persons/JustUpg/b3.png");
            
            childSprite4.sortingLayerName = person.Limbs[0].GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite4.sortingOrder = person.Limbs[0].GetComponent<SpriteRenderer>().sortingOrder + 1;
            childSprite3.sortingLayerName = person.Limbs[0].GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite3.sortingOrder = person.Limbs[0].GetComponent<SpriteRenderer>().sortingOrder + 1;
            childSprite2.sortingLayerName = person.Limbs[0].GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite2.sortingOrder = person.Limbs[0].GetComponent<SpriteRenderer>().sortingOrder + 1;
            childSprite.sortingLayerName = person.Limbs[0].GetComponent<SpriteRenderer>().sortingLayerName;
	        childSprite.sortingOrder = person.Limbs[0].GetComponent<SpriteRenderer>().sortingOrder + 2;

		    someobject2.GetComponent<Rigidbody2D>().mass=0.0f;
	        someobject2.AddComponent<PhysicalBehaviour>().Properties = properties;
	    	someobject2.transform.parent = Instance.transform;
            var frjoint2 = someobject2.AddComponent<FixedJoint2D>();
            frjoint2.connectedBody = Instance.transform.Find("BackArm").Find("LowerArm").GetComponent<Rigidbody2D>();
	    	someobject2.transform.localPosition = new Vector2(-0.06f,-0.45f);
	    	someobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            someobject2.transform.localScale = new Vector3(0f, 0f);
        for(int i = 0; i < 14; i++)
        {
            Physics2D.IgnoreCollision(someobject2.GetComponent<Collider2D>(), person.Limbs[i].GetComponent<BoxCollider2D>());
        };
		var glow = ModAPI.CreateLight(Instance.transform.Find("BackArm").Find("LowerArm"), Color.red, 0, 1);
		glow.transform.localPosition = new Vector3(0f,-0.5f,0f);
		var blade_on = ModAPI.LoadSound("audio/blade_on.wav");
		var blade_of = ModAPI.LoadSound("audio/blade_of.wav");
		var bladeSound1 = person.Limbs[1].gameObject.AddComponent<AudioSource>();
		bladeSound1.clip = blade_on;
		var bladeSound2 = person.Limbs[2].gameObject.AddComponent<AudioSource>();
		bladeSound2.clip = blade_of;
		bool use = false;
        bool use2 = true;
		person.Limbs[1].gameObject.AddComponent<UseEventTrigger>().Action = () =>
		{
		if (use == false)
			{       
				glow.Radius = 5;
				glow.transform.localScale = new Vector3(0.5f, 1.5f);
				bladeSound1.Play();
				someobject2.transform.localScale = new Vector3(1f, -1f);
				someobject2.GetComponent<Rigidbody2D>().useAutoMass=true;
				somesprite2.sortingLayerName = "Bottom";
				use = true;
			}
		else
			{
                someobject2.GetComponent<Rigidbody2D>().useAutoMass=false;
				glow.Radius = 0;
				bladeSound2.Play();
				someobject2.transform.localScale = new Vector3(0f, 0f);
				use = false;
			};
		};
        
        var mask_obj = new GameObject("mask");
        mask_obj.transform.SetParent(person.Limbs[0].transform);
        var mask_sprite = mask_obj.AddComponent<SpriteRenderer>();
        mask_sprite.sprite = ModAPI.LoadSprite("persons/JustUpg/mask_obj.png");
        mask_obj.transform.localPosition = new Vector2(0f,0);
	    mask_obj.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
        mask_obj.transform.localScale = new Vector3(1f, 1f);
            mask_sprite.sortingLayerName = person.Limbs[0].GetComponent<SpriteRenderer>().sortingLayerName;
	        mask_sprite.sortingOrder = person.Limbs[0].GetComponent<SpriteRenderer>().sortingOrder + 1;

        person.Limbs[0].gameObject.AddComponent<UseEventTrigger>().Action = () =>
		{
		if (use2 == false)
			{       
                person.SetBodyTextures(skin, flesh, bone, 1);
                mask_obj.GetComponent<Rigidbody2D>().simulated = false;
                mask_obj.transform.SetParent(person.Limbs[0].transform);
                mask_obj.transform.localPosition = new Vector2(0f,0f);
	            mask_obj.transform.rotation = Quaternion.Euler(Head.transform.eulerAngles);
                mask_obj.transform.localScale = new Vector3(1f, 1f);
                use2 = true;
			}
		else
			{
                person.SetBodyTextures(skin2, flesh, bone, 1);
                ModAPI.CreateParticleEffect("FuseBlown",mask_obj.transform.position);
                ModAPI.CreateParticleEffect("Vapor",mask_obj.transform.position);
                mask_obj.transform.SetParent(null);
                mask_obj.AddComponent<PhysicalBehaviour>();
                mask_obj.AddComponent<Rigidbody2D>();
                mask_obj.GetComponent<Rigidbody2D>().inertia = 1;
                mask_obj.GetComponent<Rigidbody2D>().simulated = true;
                    mask_obj.GetComponent<Rigidbody2D>().velocity = new Vector3(4.3f, -1f, 0f);
                    mask_obj.GetComponent<Rigidbody2D>().angularVelocity = -180f;

                
                use2 = false;
			};
		};
       }
    }
); 

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"), 
                    NameOverride = ModTag +"Ris",
                    DescriptionOverride = "idk who is it, but R3lax know him. He is bad... ",
                    CategoryOverride = ModAPI.FindCategory("FM"),
                    ThumbnailOverride = ModAPI.LoadSprite("persons/ris/5.png"),
                    AfterSpawn = (Instance) => 
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();

                        var Head = Instance.transform.Find("Head").gameObject;

                        Head.GetOrAddComponent<MultipleSpriteHumanBehaviour>().person = person;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Scale = 1;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Textures = new Texture2D[]
                        {
                            ModAPI.LoadTexture("persons/ris/Ris.png"),
                        };
                    }
                }
            );

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"), 
                    NameOverride = ModTag + "Life_plz",
                    DescriptionOverride = "MAN!!! \n oh..it's D1e_plz? or L1fe_plz idk XD ",
                    CategoryOverride = ModAPI.FindCategory("FM"),
                    ThumbnailOverride = ModAPI.LoadSprite("persons/L1fe/42.png"),
                    AfterSpawn = (Instance) => 
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();

                        var Head = Instance.transform.Find("Head").gameObject;

                        Head.GetOrAddComponent<MultipleSpriteHumanBehaviour>().person = person;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Scale = 1;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Textures = new Texture2D[]
                        {
                            ModAPI.LoadTexture("persons/L1fe/D1e_plz.png"),
                        };
                    }
                }
            );
 ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"), 
                    NameOverride = ModTag +"Who_plz",
                    DescriptionOverride = "Who i am? \n he's... uh.. a hybrid of D1e_plz and L1fe_plz ",
                    CategoryOverride = ModAPI.FindCategory("FM"),
                    ThumbnailOverride = ModAPI.LoadSprite("persons/who_plz/2.png"),
                    AfterSpawn = (Instance) => 
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();

                        var Head = Instance.transform.Find("Head").gameObject;

                        Head.GetOrAddComponent<MultipleSpriteHumanBehaviour>().person = person;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Scale = 1;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Textures = new Texture2D[]
                        {
                            ModAPI.LoadTexture("persons/who_plz/Just_Who.png"),
                        };
                    }
                }
);


 ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"), 
                    NameOverride = ModTag +"Zmeenocec",
                    DescriptionOverride = "idk why he in mod? Just_R3lax is involved in this ",
                    CategoryOverride = ModAPI.FindCategory("FM"),
                    ThumbnailOverride = ModAPI.LoadSprite("persons/zmee/43.png"),
                    AfterSpawn = (Instance) => 
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();

                        var Head = Instance.transform.Find("Head").gameObject;

                        Head.GetOrAddComponent<MultipleSpriteHumanBehaviour>().person = person;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Scale = 1;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Textures = new Texture2D[]
                        {
                            ModAPI.LoadTexture("persons/zmee/Zmeenocec.png"),
                        };
                    }
                }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = ModTag +"TBOROWO4EK28",
        DescriptionOverride = "Yummy ",
        CategoryOverride = ModAPI.FindCategory("FM"),
        ThumbnailOverride = ModAPI.LoadSprite("persons/tBoro/888.png"),
	
        AfterSpawn = (Instance) =>
        {
var person = Instance.GetComponent<PersonBehaviour>();

            var Head = Instance.transform.GetChild(5);
	        var skin = ModAPI.LoadTexture("persons/tBoro/TBOROWO4EK28.png");
            var flesh = ModAPI.LoadTexture("other_sprites/flesh.png");
            var bone = ModAPI.LoadTexture("other_sprites/bone.png");	

            var childObject = new GameObject("hairs");
            childObject.transform.SetParent(Head);
            childObject.transform.localPosition = new Vector3(0f, 0f);
            childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            childObject.transform.localScale = new Vector3(1f, 1f);
            var childSprite = childObject.AddComponent<SpriteRenderer>();
            childSprite.sprite = ModAPI.LoadSprite("persons/tBoro/Hair_Female_7.png");

            childSprite.sortingLayerName = Head.GetComponent<SpriteRenderer>().sortingLayerName;
	    childSprite.sortingOrder = Head.GetComponent<SpriteRenderer>().sortingOrder + 1;
	    

            


            person.SetBodyTextures(skin, flesh, bone, 1);
        }
    }
); 

ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"), 
                    NameOverride = ModTag +"D1o_plz",
                    DescriptionOverride = "It was the one i experimented on the most. ",
                    CategoryOverride = ModAPI.FindCategory("FM"),
                    ThumbnailOverride = ModAPI.LoadSprite("persons/Dio/1.png"),
                    AfterSpawn = (Instance) => 
                    {
                        var person = Instance.GetComponent<PersonBehaviour>();

                        var Head = Instance.transform.Find("Head").gameObject;

                        Head.GetOrAddComponent<MultipleSpriteHumanBehaviour>().person = person;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Scale = 1;
                        Head.GetComponent<MultipleSpriteHumanBehaviour>().Textures = new Texture2D[]
                        {
                            ModAPI.LoadTexture("persons/Dio/Di0_plz.png"),
                        };
                    }
                }
            );
//hell


ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Energy Sword"),
        NameOverride = ModTag + item + "Crimson_r3lax Katana",
        DescriptionOverride = "just red resprite Energy Sword",
        CategoryOverride = ModAPI.FindCategory("FM"), 
        ThumbnailOverride = ModAPI.LoadSprite("item/swords/image.png"),
        AfterSpawn = (Instance) =>
        {
	    var properties = ModAPI.FindPhysicalProperties("Weapon");
	    var someobject = ModAPI.CreatePhysicalObject("Sword", ModAPI.LoadSprite("item/swords/blade.png"));  
            someobject.GetComponent<PhysicalBehaviour>().Properties = properties;

            someobject.transform.parent = Instance.transform;
            var frjoint = someobject.AddComponent<FixedJoint2D>();
            frjoint.connectedBody = Instance.GetComponent<Rigidbody2D>();

	    someobject.transform.localPosition = new Vector2(0f,0.7f);
	    someobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            someobject.transform.localScale = new Vector3(1f, 1f);

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("item/swords/452.png");

            properties.SharpAxes = new SharpAxis[]                                                                           
                        {
                            new SharpAxis(Vector2.up, 0f, 1f, true, true),
                        };
	    properties.Sharp = true;
		someobject.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.1f;
		Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.3f;
        

        }
    }

);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Energy Sword"),
        NameOverride = ModTag + item + "Just_r3lax Katana",
        DescriptionOverride = "just blue resprite Energy Sword",
        CategoryOverride = ModAPI.FindCategory("FM"), 
        ThumbnailOverride = ModAPI.LoadSprite("item/swords/image2.png"),
        AfterSpawn = (Instance) =>
        {	
	    var someobject = ModAPI.CreatePhysicalObject("Sword", ModAPI.LoadSprite("item/swords/blade2.png"));
            var properties = ModAPI.FindPhysicalProperties("Weapon");
            properties.SharpAxes = new SharpAxis[]
                        {
                            new SharpAxis(Vector2.up, 0f, 1f, true, true),
                        };
            someobject.GetComponent<PhysicalBehaviour>().Properties = properties;

            someobject.transform.parent = Instance.transform;
            var frjoint = someobject.AddComponent<FixedJoint2D>();
            frjoint.connectedBody = Instance.GetComponent<Rigidbody2D>();
	    someobject.transform.localPosition = new Vector2(0f,0.7f);
	    someobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
            someobject.transform.localScale = new Vector3(1f, 1f);

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("item/swords/452.png");

	    properties.Sharp = true;
		someobject.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.1f;
		Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.3f;
		


        }
    }

);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Archelix Caster"),
        NameOverride = ModTag + "A.L.P.H.A.",
        DescriptionOverride = "resprite of Archelix Caster",
        CategoryOverride = ModAPI.FindCategory("FM"), 
        ThumbnailOverride = ModAPI.LoadSprite("gun/alphaicn.png"),
        AfterSpawn = (Instance) =>
        {
            Instance.GetComponent<DamagableMachineryBehaviour>().Indestructible = true;
            var sprite = ModAPI.LoadSprite("gun/alpha.png");
            Instance.GetComponent<SpriteRenderer>().sprite = sprite;
            Instance.FixColliders();
            Instance.transform.localScale = new Vector3(0.745f, 0.745f);
            
            var glow = ModAPI.CreateLight(Instance.GetComponent<Transform>(), Color.magenta, 1.2f, 0.7f);
            glow.transform.localPosition = new Vector3(0.22f,0f,0f);
            Instance.AddComponent<UseEventTrigger>().Action = () =>
            {

            };
        }
    }
);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Rod"),
        NameOverride = ModTag + item + "Radio",
        DescriptionOverride = "This song fills you with <color=red>determination",
        CategoryOverride = ModAPI.FindCategory("FM"), 
        ThumbnailOverride = ModAPI.LoadSprite("item/radio/242.png"),
        AfterSpawn = (Instance) =>
        {
            Instance.GetComponent<Rigidbody2D>().useAutoMass=true;
            var sprite = ModAPI.LoadSprite("item/radio/241.png");
            Instance.GetComponent<SpriteRenderer>().sprite = sprite;
            Instance.FixColliders();
            int use = 0;
                var sound3 = ModAPI.LoadSound("audio/sound3.wav");
                var sound2 = ModAPI.LoadSound("audio/sound2.wav");
                var sound1 = ModAPI.LoadSound("audio/sound1.wav");
                    var SSSSOUNDONEEEE = Instance.AddComponent<AudioSource>();
		            SSSSOUNDONEEEE.clip = sound1;
                    var twolol = Instance.AddComponent<AudioSource>();
		            twolol.clip = sound2;
                    var threeSOOOUUUNNNDD = Instance.AddComponent<AudioSource>();
		            threeSOOOUUUNNNDD.clip = sound3;
            Instance.AddComponent<UseEventTrigger>().Action = () =>
            {
                if (use==0)
                {
                    use=1;
                    SSSSOUNDONEEEE.Play();
                    //play sound1
                    ModAPI.Notify("now play <color=#ff00ff>Undertale - Temmie Village");
                }
                else if (use==1)
                {
                    use=2;
                    twolol.Play();
                    SSSSOUNDONEEEE.Stop();
                    //play sound2
                    ModAPI.Notify("now play <color=#ff00ff>Terraria - Boss 1");
                }
                else if (use==2)
                {
                    use=3;
                    threeSOOOUUUNNNDD.Play();
                    twolol.Stop();
                    //play sound3
                    ModAPI.Notify("now play <color=#ff00ff>RimWorold - Ice Shaman");
                }
                else if (use==3)
                {
                    threeSOOOUUUNNNDD.Stop();
                    //stop sounds
                    use=0;
                };
            };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = ModTag + item + "Choco-pie",
        DescriptionOverride = "Yummy!..",
        CategoryOverride = ModAPI.FindCategory("FM"), 
        ThumbnailOverride = ModAPI.LoadSprite("item/cokopay/icon3.png"),
        AfterSpawn = (Instance) =>
        {

	    var sprite = ModAPI.LoadSprite("item/cokopay/532.png");
            Instance.GetComponent<SpriteRenderer>().sprite = sprite;
            Instance.FixColliders();
	    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.336f;
	    Instance.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[] {ModAPI.LoadSound("audio/chokopay.wav")};
	    Instance.AddComponent<UseEventTrigger>().Action = () =>
	{
ExplosionCreator.Explode(Instance.transform.position, 15);
Instance.GetComponent<PhysicalBehaviour>().Disintegrate();
	};

        }
    }
);


ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = ModTag + item + "Atomic Choco-pie",
        DescriptionOverride = "Radiation!..",
        CategoryOverride = ModAPI.FindCategory("FM"), 
        ThumbnailOverride = ModAPI.LoadSprite("item/Atomic_cokopay/icon3.png"),
        AfterSpawn = (Instance) =>
        {
	    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.336f;
	    Instance.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[] {ModAPI.LoadSound("audio/rad.wav")};
        var sprite = ModAPI.LoadSprite("item/Atomic_cokopay/532.png");
        Instance.GetComponent<SpriteRenderer>().sprite = sprite;
        Instance.FixColliders();
        var glow = ModAPI.CreateLight(Instance.GetComponent<Transform>(), Color.green, 1.4f, 1.4f);
        glow.transform.localPosition = new Vector3(0,0,0);
		var rad2 = Instance.AddComponent<AudioSource>();
		rad2.clip = ModAPI.LoadSound("audio/rad2.wav");
        rad2.loop = true;
        rad2.volume = 0.07f;
        rad2.Play();
        Instance.AddComponent<UseEventTrigger>().Action = () =>
	    {
            ExplosionCreator.Explode(Instance.transform.position, 7500);
            Instance.GetComponent<PhysicalBehaviour>().Disintegrate();
	};
        }
    }
);


ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Detached Ray Cannon"),
        NameOverride = ModTag + "B.E.T.A.",
        DescriptionOverride = "resprite of Detached Ray Cannon",
        CategoryOverride = ModAPI.FindCategory("FM"), 
        ThumbnailOverride = ModAPI.LoadSprite("gun/betaicn.png"),
        AfterSpawn = (Instance) =>
        {
	    var properties = ModAPI.FindPhysicalProperties("Weapon");
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("gun/beta.png");
            Instance.FixColliders();
	Instance.AddComponent<UseEventTrigger>().Action = () =>
	{
	};
        }
    }
);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Rod"),
        NameOverride = ModTag + "test",
        DescriptionOverride = "test",
        CategoryOverride = ModAPI.FindCategory("FM Accs"), 
        ThumbnailOverride = ModAPI.LoadSprite("other_sprites/TEST_TUMB.png"),
        AfterSpawn = (Instance) =>
        {
            var Sprite = Instance.GetComponent<SpriteRenderer>();
            Sprite.sprite = ModAPI.LoadSprite("persons/alt_d1e/hat.png");
            Instance.FixColliders();
        }
    });


}

//--------------------------------------------------------------------------------------
public class MultipleSpriteHumanBehaviour : MonoBehaviour
    {
        public Texture2D[] Textures = new Texture2D[0];
        public PersonBehaviour person;
        public int CurrentTexture = -2;
        public int Scale = 3;

        void Start()
        {
            SetTexture();
        }

        public void SetTexture()
        {
            if (Textures.Length == 0)
                return;

            if(CurrentTexture == -2)
            {
                CurrentTexture = UnityEngine.Random.Range(0, Textures.Length);
            }
            person.SetBodyTextures(Textures[CurrentTexture], null, null, Scale);
            for (int i = 0; i < person.Limbs.Length; i++)
            {
                person.Limbs[i].gameObject.GetComponent<PhysicalBehaviour>().RefreshOutline();
            }
        }
}	}}