using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types.Enums;

namespace revcom_bot
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw;


        public Form1()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

            this.bw = new BackgroundWorker();
            this.bw.DoWork += bw_DoWork;
        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var keyboardLast = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                ResizeKeyboard = true
            };
            var keyboardWait = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Ожидайте загрузки текста"),
                                                },
                                            },
                ResizeKeyboard = true
            };
            
            var keyboardDoor2 = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Войти во вторую дверь"),
                                                },
                                            },
                ResizeKeyboard = true
            };
            var keyboardDoor3 = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Войти в третью дверь"),
                                                },
                                            },
                ResizeKeyboard = true
            };
            var keyboardDoor4 = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Войти в четвертую дверь"),
                                                },
                                            },
                ResizeKeyboard = true
            };
            var keyboardDoor5 = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Войти в пятую дверь"),
                                                },
                                            },
                ResizeKeyboard = true
            };
            var keyboardDoor6 = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Войти в шестую дверь"),
                                                },
                                            },
                ResizeKeyboard = true
            };
            var keyboard6 = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Перейти к эпилогу"),

                                                },
                                                

                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                ResizeKeyboard = true
            };
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String; // получаем ключ из аргументов
            try
            {
                var Bot = new Telegram.Bot.TelegramBotClient(key); // инициализируем API
                await Bot.SetWebhookAsync(""); // Обязательно! убираем старую привязку к вебхуку для бота

                // Inlin'ы
                Bot.OnInlineQuery += async (object si, Telegram.Bot.Args.InlineQueryEventArgs ei) =>
                {
                    var query = ei.InlineQuery.Query;

                    var msg = new Telegram.Bot.Types.InputMessageContents.InputTextMessageContent
                    {
                        MessageText = @"Это супер крутой текст статьи
с переносами
и <b>html</b> <i>тегами!</i>",
                        ParseMode = Telegram.Bot.Types.Enums.ParseMode.Html,
                    };

                    Telegram.Bot.Types.InlineQueryResults.InlineQueryResult[] results = {
                        new Telegram.Bot.Types.InlineQueryResults.InlineQueryResultArticle
                        {
                            Id = "1",
                            Title = "Тестовый тайтл",
                            Description = "Описание статьи тут",
                            InputMessageContent = msg,
                        },
                        new Telegram.Bot.Types.InlineQueryResults.InlineQueryResultAudio
                        {
                            Url = "http://aftamat4ik.ru/wp-content/uploads/2017/05/mongol-shuudan_-_kozyr-nash-mandat.mp3",
                            Id = "2",
                            FileId = "123423433",
                            Title = "Монгол Шуудан - Козырь наш Мандат!",
                        },
                        new Telegram.Bot.Types.InlineQueryResults.InlineQueryResultPhoto
                        {
                            Id = "3",
                            Url = "http://aftamat4ik.ru/wp-content/uploads/2017/05/14277366494961.jpg",
                            ThumbUrl = "http://aftamat4ik.ru/wp-content/uploads/2017/05/14277366494961-150x150.jpg",
                            Caption = "Текст под фоткой",
                            Description = "Описание",
                        },
                        new Telegram.Bot.Types.InlineQueryResults.InlineQueryResultVideo
                        {
                            Id = "4",
                            Url = "http://aftamat4ik.ru/wp-content/uploads/2017/05/bb.mp4",
                            ThumbUrl = "http://aftamat4ik.ru/wp-content/uploads/2017/05/joker_5-150x150.jpg",
                            Title = "демо видеоролика",
                            MimeType = "video/mp4",
                        }
                    };


                    await Bot.AnswerInlineQueryAsync(ei.InlineQuery.Id, results);
                };

                // Callback'и от кнопок
                Bot.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
                {
                    var message = ev.CallbackQuery.Message;
                    if(ev.CallbackQuery.Data == "callback1") {
                        await Bot.AnswerCallbackQueryAsync(ev.CallbackQuery.Id, "You hav choosen " + ev.CallbackQuery.Data, true);
                    } else 
                    if (ev.CallbackQuery.Data == "callback2")
                    {
                        await Bot.SendTextMessageAsync(message.Chat.Id, "тест", replyToMessageId: message.MessageId);
                        await Bot.AnswerCallbackQueryAsync(ev.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "частики" на кнопке
                    }
                };

                Bot.OnUpdate += async (object su, Telegram.Bot.Args.UpdateEventArgs evu) =>
                {
                    if (evu.Update.CallbackQuery != null || evu.Update.InlineQuery != null) return; // в этом блоке нам келлбэки и инлайны не нужны
                    var update = evu.Update;
                    var message = update.Message;
                    /// <summary>
                    /// Saves the keyboards in text files
                    /// </summary>
                    /// <param name="Chat_id">Unique identifier for the target chat or username of the target channel</param>
                    /// <param name="keyboards">Strings for saving</param>
                    void Keys_to_file(long Chat_id, string[] keyboards)
                    {
                        string writePath = Convert.ToString(Chat_id) + ".txt";
                        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.UTF8))
                        {
                            for (int i = 0; i < keyboards.Length; i++)
                            {
                                sw.WriteLine(keyboards[i]);
                            }
                        }
                    }

                
                    List<string> Keys_out_file(long Chat_id)
                    {
                        string readPath = Convert.ToString(Chat_id) + ".txt";
                        List<string> mas = new List<string>();
                        using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.UTF8))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                mas.Add(line);
                            }
                        }
                        return mas;
                    }

                    if (message == null) return;
                    try
                    {
                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                        {
                            if (message.Text == "/start")
                            {
                                string prolog = "<i>Пролог \n\n Во времена, когда все люди были одинаковы, а дни были похожи на все предыдущие, кто-то сказал: «Я хочу измениться». Он первый дал толчок развитию. И тогда другие задумались: «Неужели я хуже него? Неужели я не могу измениться?..»\n\nНо прошло время.  Одни люди развивались медленнее, другие – быстрее. Подобно звездам, одни разгорались ярче других. И тогда родилась зависть…\n\nТе, что горели слабее других, начали смеяться над другими. Порой тьма в их сердцах была так сильна, что толкала на ужасающие поступки. Люди начали бояться «гореть»…\n\nВ страхе стать высмеянными и униженными отверженцами, они остановились. С каждым днем свет искр в их сердцах все тускнел и тускнел, до тех пор, пока не померк вовсе…\n\nЛюди снова стали похожими и одинаковыми. Мир стал грозовым  небом, которое заволокли тучи… Человеческие мечты, словно большие капли, переполненные боли, печали и отчаяния, начали срываться вниз…\n\nНо далеко не все были готовы с этим смириться. И тогда кто-то сказал: «Я выдержу!» - так родилась смелость. Она огромной молнией в один миг прорезала и озарила небосвод человеческих душ…\n\nЭто никому не понравилось… Капли все падали и падали, дождь перерос в град, желая покорить выскочку, но он не был одним… Вслед за ним небо прорезали и другие молнии. Их было совсем немного, но сила их сердец была настолько велика, что тучи отступили… В человеческих сердцах вновь загорелись звезды. Сперва их свет был едва заметен, но с годами они разгорались все ярче и их свет дал рождение новой эпохе. Эпохе, в которую никто не боялся «гореть»…\n\n«Интересно, смогу ли я стать таким же? Сейчас каждый мой день похож на предыдущий. Смогу ли я победить свои страхи, страхи других людей и «гореть» так же ярко, как сердца людей в легенде? Смогу ли я измениться?\n\nЯ никогда не задумывался о том, чего хочу… Наверное у многих сейчас это самые банальные желания, вроде успешного окончания учебы, хорошая работа, семья, любовь… Я не знаю, важно ли все это для меня… Есть ли в этом мире что-нибудь по-настоящему важное? \n\nВ мире, где каждый ищет, ради чего ему жить, смогу ли я найти это что-то когда-нибудь?..»</i>\n";
                                // в ответ на команду /saysomething выводим сообщение
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Продолжить"),
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                //keyboardLast = keyboard;
                                string[] keys = { "Продолжить","/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, prolog, false, false, 0, keyboard, ParseMode.Html);
                                //await Bot.SendTextMessageAsync(message.Chat.Id, "Давай накатим, товарищ, по одной!", false, false, 0, keyboard, Telegram.Bot.Types.Enums.ParseMode.Default);
                            }
                            else if (message.Text == "Продолжить")
                            {
                                // в ответ на команду Начать игру выводим комнату с дверьми
                                //await Bot.SendPhotoAsync(message.Chat.Id, "http://aftamat4ik.ru/wp-content/uploads/2017/03/photo_2016-12-13_23-21-07.jpg", "Revolution!");
                                string Room_with_doors = "Комната странных дверей \n<i>Я очнулся на холодном полу, напоминающем шахматную доску без фигур. Я не знал, где я и что здесь делаю. Я не помнил, где и как засыпал, я даже не помнил, кто я, но уверенность в том, что здесь я никогда раньше не бывал, не покидала меня. \n\nЯ поднялся на ноги, чувствуя тяжесть во всем теле. Кажется, каждая мышца потеряла свою форму.\n\nВопросы один за другим прокрадывались в мою голову. Давно ли я здесь? Зачем? Что делать дальше? Я не имел ни малейшего понятия.\n\nГлаза резал яркий свет. Понадобилось время, чтобы к нему привыкнуть. Лишь спустя несколько минут мне удалось осмотреться.\n\nКомната была круглой. Меня окружали двери самых разных форм и размеров, материалов и цветов. Во всех них было что-то странное, что-то неправильное. Они явно отличались от тех, что мне довелось видеть раньше.\n\n Двери – единственное, что меня окружало. Подле меня не было никаких посторонних предметов. Все, что мне оставалось – войти в одну из них…\n\n</i>";
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Войти в первую дверь"),
                                                    
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                }
                                            },
                                    ResizeKeyboard = true
                                };
                                string[] keys = { "Войти в первую дверь", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, Room_with_doors, false, false, 0, keyboard, ParseMode.Html);
                            }
                            else if (message.Text == "Ожидайте загрузки текста")
                            {

                            }
                            //дверь №1
                            else if (message.Text == "Войти в первую дверь")
                            {
                                // в ответ на команду Начать игру выводим комнату с дверьми
                                //await Bot.SendPhotoAsync(message.Chat.Id, "http://aftamat4ik.ru/wp-content/uploads/2017/03/photo_2016-12-13_23-21-07.jpg", "Revolution!");
                                string door1 = "Дверь первая \n\n Первая дверь, перед которой я оказался, была выполнена из темного дерева с резным узором и вставками из неизвестного мне метала. Не знаю, почему выбрал именно ее.\n\nНеуверенно я шагнул вперед и потянул ручку на себя.\n\nТак началось мое путешествие…\n\n";
                                
                                await Bot.SendTextMessageAsync(message.Chat.Id, door1, false, false, 0, keyboardWait, ParseMode.Html);
                                //Telegram.Bot.Types.FileToSend audio = new Telegram.Bot.Types.FileToSend("opening.mp3", );
                                //await Bot.SendAudioAsync(message.Chat.Id, Telegram.Bot.Types.FileToSend , "Pixie Paris", "Opening", false,0,null);
                                //"opening.mp3"
                                //await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadAudio);

                                //const string file = @"opening.mp3";

                                //var fileName = file.Split(Path.DirectorySeparatorChar).Last();

                                //using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                                //{
                                //    Telegram.Bot.Types.Message x= await Bot.SendAudioAsync(
                                //        message.Chat.Id,
                                //        new Telegram.Bot.Types.FileToSend("opening.mp3", fileStream),
                                //        150,
                                //        "Pixie",
                                //        "Opening", false, 0, null
                                //        );

                                //}
                                string req = "https://api.telegram.org/bot508343926:AAHaaWy-GnJJnYAWIgd6NxzHq8TjY5GTGm0/sendDocument?chat_id="+Convert.ToString(message.Chat.Id) + "&document=CQADAgAD7QADa6gJS67YWb1azh1_Ag";
                                WebRequest n = WebRequest.Create(req);
                                string line;
                                WebResponse response = n.GetResponse();
                                using (Stream stream = response.GetResponseStream())
                                {
                                    using (StreamReader reader = new StreamReader(stream))
                                    {
                                        line = "";
                                        while ((line = reader.ReadLine()) != null)
                                        {
                                            Console.WriteLine(line);
                                        }
                                    }
                                }
                                response.Close();

                                string door11 = "<i>Шагнув через порог, я оказался на лестничной клетке перед другой дверью. Не знаю, как это произошло. Кажется, я нахожусь в каком то здании. \n\n Я не помню, чтобы звонил или стучал в дверь, но там, с той стороны, послышались приближающиеся шаги. Через пару секунд она распахнулась и передо мной оказалась милая длинноволосая брюнетка с карими глазами. Она была среднего роста.</i>";
                                Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door11, false, false, 0, keyboardWait, ParseMode.Html);
                                string door12 = "- Братик?";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door12, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                string door13 = "- Братик?..  – <i>недоуменно переспросил я. \n\nНеужели эта девушка – моя сестра?</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door13, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                string door14 = "<i>Она оценивающе посмотрела на меня, в мгновение ока изменившись в лице.  Мне это не понравилось. Взгляд стал суровым. Не успел я опомниться, как та, которую я несколько минут назад опрометчиво посчитал милашкой, размахнулась и изо всех сил врезала мне по лицу кулаком. Да так, что я чуть было не потерял равновесие.</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door14, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                string door_15 = "- Снова пил со своими друзьями?! А я-то волновалась, думала, где же ты шастал всю ночь, а оно вот как! Это же до каких соплей и чертиков нужно было напиться, чтобы сестру родную не признать?! Небось и имени моего не помнишь?!  - <i>я виновато посмотрел на нее и она тяжело выдохнула</i>.";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_15, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                string door_16 = "- Прости, я совершенно ничего не помню. Не знаю, что произошло.";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_16, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                string door_17 = "-Серьезно ? – <i> брюнетка еще какое-то время сверлила меня недоверчивым взглядом, а затем смирилась.Даже выражение ее лица стало более мягким, я бы сказал несколько обеспокоенным </i>.";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_17, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                string door_18 = "-Мне очень жаль.";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_18, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                //отсюда начинать вызывать эвэйты сендов (дур 19)
                                string door_19 = "- Что с тобой поделаешь?..  Я – Алена. Твоя младшая сестра. Мы живем вместе с родителями здесь, в этом доме, но сейчас их нет, потому что они уехали в отпуск. Может ты головой ударился? Свое-то имя помнишь? –<i> я лишь покачал головой</i>.";
                                string door_110 = "- Нет.";
                                string door_111 = "- Миша. Тебя зовут Миша. Ты как? Голова не кружится?";
                                string door_112 = "- Да нет, вроде. Чувствую себя обычно.";
                                string door_113 = "- Ладно. Хватит нам на пороге стоять.  Заходи. Пообедаем и съездим в больницу. Нужно узнать, что с тобой, - <i>не найдя причин для отказа, я легонько кивнул и проследовал за ней в просторную квартиру</i>.";
                                string door_114 = "- Ну как? Вспоминаешь что-нибудь? –<i> спросила она, заваривая чай</i>.";
                                string door_115 = "- Мне жаль… Но, сколько ни пытаюсь, ничего не узнаю.";
                                string door_116 = "- Это кажется серьезным… Вроде алкоголем и не пахнет, зрачки в норме, да и координация тоже, не шатаешься ведь.";
                                string door_117 = "<i>Я не знал, что ответить ей. Я и про себя не знаю ничего, кроме имени. И то, благодаря ней.\n\nКажется, Алена поняла, что пытаться расспросить меня бесполезно, а потому отвернулась к столу, занявшись ужином. Это должно было быть мясо в гарнире. Пахло довольно аппетитно, поэтому я не стал покидать кухню, наблюдая за ее спиной и изредка поглядывая в окно</i>.";
                                string door_118 = "- Довольно высоко… Какой этаж?";
                                string door_119 = "- Шестнадцатый. Ты ведь сам поднимался. Разве не помнишь? – <i>я опустил плечи, услышав очередной печальный вздох</i>, - Ничего, прости, я просто… Никак в голове не укладывается… Нужно скорее показать тебя доктору.";
                                string door_120 = "- Наверное… Было бы здорово все вспомнить… - сестра постаралась улыбнуться, но я знал, с каким трудом ей это удалось.";
                                string door_121 = "- Ты обязательно все вспомнишь, обещаю тебе…";
                                string door_122 = "<i>Однако у врача было свое мнение на этот счет. По результатам обследования, у меня не было никаких травм или веществ в организме, которые могли бы вызвать амнезию. Была теория, что утрата памяти вызвана психологическими факторами, но, увы, как ни старался, я ни мог ни подтвердить, ни опровергнуть ее.\n\nМне сказали, я могу вспомнить через какое-то время. Не все, но кусочками память будет возвращаться в подходящей среде. Алена была расстроена, а я ничего не испытывал. Я не знал, какой была моя жизнь до этого, поэтому не мог быть опечален или обрадован этим фактом</i>.";
                                string door_123 = "- Я… Я не стану пока ничего говорить родителям, хорошо? Они очень расстроятся и будут волноваться… Они так ждали этой поездки к морю…";
                                string door_124 = "- Да, конечно…";
                                string door_125 = "- Может твоя память вернется раньше? До того, как они приедут? – <i>я чувствовал, что не успею, но сидя рядом с ней и глядя в ее глаза, полные грусти и надежды, не мог сказать «нет»</i>.";
                                string door_126 = "- Может быть, - я улыбнулся и провел рукой по ее щеке. Алена покраснела.";
                                string door_127 = "- Э-э-э… Наверное мне стоит заняться ужином. Завтра подумаю над тем, как вернуть тебе память. Можешь пока что отдохнуть.";
                                string door_128 = "<i>Я лежал в гостиной на диване, слепо уставившись с потолок. Сейчас я ничем не отличаюсь от овоща. Да, я могу разговаривать, могу думать, но о чем, если я совершенно ничего не помню?\n\nМой взгляд сам собой начал бродить по комнате.\n\nЕсли то, что сказал врач – правда, что-то здесь должно мне помочь вспомнить хоть что-нибудь. Как-никак, по словам сестры, я прожил здесь почти двадцать лет. Но я не чувствовал, что это так. Все вокруг, все, что я видел, было таким чужим. Словно сон</i>.";
                                string door_129 = "- Так ничего и не вспомнил? –<i> Алена вошла в комнату с тарелками</i>.";
                                string door_130 = "- Ничего, -<i> подтвердил я</i>.";
                                string door_131 = "- Что ж. Тебе нужно время. Я приготовила твой любимый салат с помидорами, сладким перцем и мясом. ";
                                string door_132 = "- Спасибо.";
                                string door_133 = "- Не за что… Я надеялась, это хоть немножечко поможет.";
                                string door_134 = "<i>Стоило мне попробовать одну ложку, как мои глаза сперва закрылись от удовольствия, затем широко распахнулись</i>.";
                                string door_135 = "- Что? Пересолила? Так и знала, нужно было меньше соли …";
                                string door_136 = "- Нет же! Кажется, я помню этот вкус!";
                                string door_137 = "- Правда? Ну слава богу… Значит не все потеряно… Я так рада…";
                                string door_138 = "<i>Глядя на то, как она улыбается, было невозможно не улыбнуться в ответ. Было что-то особенное в ее глазах, улыбке, волосах, небрежно спадающих на плечи…</i>";
                                string door_139 = "- Братик… Прости меня…";
                                string door_140 = "- М-м-м?.. За что? –<i> непонимающе спросил я</i>.";
                                string door_141 = "- За то, что ударила, когда ты пришел. Просто… Твоя амнезия… Все это как будто не наяву. Тебя не было всю ночь, я переживала. А, когда ты не узнал меня, я не знала, как реагировать… Сейчас мне очень стыдно…";
                                string door_142 = "- Да ничего. Щека уже почти не болит.";
                                string door_143 = "- Правда?";
                                string door_144 = "- Правда. Хотя у тебя отличный удар правой.";
                                string door_145 = "<i>Алена покраснела пуще преждего. И, так же неожиданно, как и в прошлый раз, заехала мне по щеке</i>.";
                                string door_146 = "- Братик – дурак! – <i>закричала она убегая</i>.";
                                string door_147 = "- И левой тоже ничего, -<i> заметил я и рассмеялся</i>.";
                                string door_148 = "<i>Так как делать все равно ничего не оставалось, я решил помочь сестре и вымыл посуду.\n\nНадеюсь, завтра я вспомню больше…</i>";
                                string door_149 = "<i>Мне снился странный сон.\n\nЯ шел по незнакомым улицам, чувствуя на себе чей-то пристальный взгляд. Кто-то следил за мной. Я пытался заворачивать за углы, скрываться, но от него было не спрятаться.\n\nИнстинкт подсказывал мне, что нужно бежать, но любопытство и другое, неведомое чувство, жаждали ответа на вопрос. Кто следит за мной?\n\nЯ попытался обвести преследователя вокруг пальца, позволив ему приблизиться, чтобы я успел рассмотреть его, но, стоило мне обернуться, как он тут же исчезал…</i>";
                                string door_150 = "<i>Сегодня мое утро началось с хлопьев, залитых молоком. Сестра сказала, мы часто ели это в детстве вместе. Было вкусно.\n\nМы пересмотрели кучу моих любимых фильмов, по словам сестры. Алена сказала, что завидует мне. Что хотела бы стереть себе память, лишь бы пересмотреть все, что любит, снова, как впервые. Сейчас они не вызывают у нее тех же чувств и эмоций, как когда-то.\n\nВсе следующие дни мы тратили на изучение всего, что я когда-либо любил: еда, музыка, фильмы, книги, комиксы, места. Казалось, всему этому не было конца.</i>";
                                string door_151 = "- Ты действительно так хорошо меня знала…";
                                string door_152 = "- Конечно! Ты же мой брат!";
                                string door_153 = "- Спасибо тебе.";
                                string door_154 = "- Ну и… как? Вспоминаешь что-нибудь?";
                                string door_155 = "- Думаю да. ";
                                string door_156 = "- Правда?! – <i>Алена радостно вскрикнула</i>, - Слава Богу!";
                                string door_157 = "- Это все благодаря тебе…";
                                string door_158 = "<i>Но это было ложью. Я солгал, чтобы она улыбнулась. Я не узнавал ничего из того, с чем мы сталкивались, но Алена так жаждала, чтобы я вспомнил…\n\nЯ не мог объяснить, что чувствую к ней и чувствую ли что-то вовсе, но продолжал делать вид, что вспоминаю, продолжал смотреть на нее, на ее улыбку. Пока она улыбалась, я чувствовал, что все хорошо, все так, как и должно быть, но, как-то раз она ушла, оставив меня на несколько часов, и вернулась очень грустной</i>.";
                                string door_159 = "- Алена? Ты плачешь? Что случилось? Кто тебя расстроил?";
                                string door_160 = "- Я… Мне нужно  немного времени, чтобы прийти в себя. Прости, сегодня я не смогу провести время с тобой. Мне правда жаль.";
                                string door_161 = "- Ничего, я понимаю… Просто я очень волнуюсь за тебя, Ален… Ты точно не хочешь об этом поговорить?";
                                string door_162 = "- Да… По крайней мере не сегодня.";
                                string door_163 = "- Ну… Тогда тебе лучше отдохнуть сейчас.";
                                string door_164 = "- И тебе. ";
                                string door_165 = "- Хорошо. Сладких снов.";
                                string door_166 = "- Сладких снов…";
                                string door_167 = "<i>Я не мог уснуть.\n\nЧувство, что я что-то упустил здесь, что-то важное, что-то, что действительно поможет мне вспомнить, не покидало меня.\n\nВзад-вперед я бродил по комнате, рассматривая полки и содержимое закрытых шкафов. Все это мы уже видели. Та, другая вещь, должна отличаться…\n\nЛишь спустя полчаса, если не больше, я смог натолкнуться на нечто, что могло являться ею. Это был фотоальбом.\n\nНа вид ничего необычного в нем не было, но внутренний голос подсказывал мне, что это не так.\n\nС колотящимся сердцем я открыл его. Там, как ни странно, оказались фотографии.\n\nНе так скоро, как хотелось, но я узнал себя в маленьком младенце, затем, примерно в возрасте пяти лет, меня начали фотографировать с двухлетней Аленой. Фотографии были самыми разными. Казалось, кто-то собирал их всю мою жизнь.\n\nо ни одна фотография меня не зацепила так, как последняя. В ней не было бы ничего особенного, если бы я не вспомнил одну деталь. Там, с краю, мелькнули голубые локоны какой-то девушки. Не знаю, кто она, но я определенно помнил ее раньшe\n\nКажется, я на шаг приблизился к разгадке…</i>";
                                string door_168 = "<i>Наутро я рассказал о том, что показалось мне знакомым, Алене, но, когда я ее спросил про девушку с голубыми волосами, она ответила, что я никогда раньше не общался с ней</i>.";
                                string door_169 = "- Странно. Я был уверен, что знал ее, кем бы она ни была…";
                                string door_170 = "- Возможно, вы виделись когда-то раз или два. Сейчас  странный цвет волос – не редкость. Многие девушки красятся. Но я правда не помню, чтобы кто-то из твоего окружения был таким…";
                                string door_171 = "- Ничего. Скорее всего, ты права. Просто из-за этой амнезии я начал цепляться за все, что можно…";
                                string door_172 = "- Это не твоя вина. Любой бы чувствовал себя потерянным на твоем месте…";
                                string door_173 = "- Кстати говоря, я ведь так и не спросил тебя о том, что случилось вчера.";
                                string door_174 = "<i>Алена мгновенно помрачнела</i>.";
                                string door_175 = "- Я… поругалась с Ваней…";
                                string door_176 = "- Кто это?";
                                string door_177 = "- Ах, да… Ты ведь ничего не помнишь… Он – мой парень… Мы часто ругаемся, когда он пьет… Честно, я не знаю, что мне делать. Не думаю, что он любит меня. Постоянно оскорбляет, вчера поднял руку на меня… Возможно было бы лучше, если бы мы с ним расстались… Это так больно, Миш. Я знаю, я ведь не самая умная и красивая, и характер у меня тот еще… Но… Неужели я настолько плохая, что заслужила нечто подобное?.. –<i> Алена всхлипнула.</i>";
                                string door_178 = "- Ты шутишь? Конечно, я не помню этого отморозка, но если он не ценит тебя, он – настоящий кретин. Не знаю, что ты там думаешь про себя, но ты – добрая, красивая, заботливая и я не знаю никого, кто бы готовил лучше тебя. И это не потому, что я их не помню.";
                                string door_179 = "- А ты помнишь?..";
                                string door_180 = "- Нет.";
                                string door_181 = "<i>Она рассмеялась.</i>";
                                string door_182 = "- Спасибо тебе, Миш. Вот бы все думали так же, как и ты…";
                                string door_183 = "- Не грусти. Я вот думаю… Все это время мы делали только то, что помогло бы вернуть мою память.  Не пора ли сделать что-нибудь для тебя?";
                                string door_184 = "- Что например?";
                                string door_185 = "- Не знаю. Чего ты хочешь? Что ты любишь? Где ты любишь бывать?";
                                string door_186 = "- Я… я давно не бывала в кино… Ваня… Он не тот, с кем было бы не стыдно туда идти, а подруги… У меня их практически нет…";
                                string door_187 = "- Значит решено. Идем в кино. Только на что?";
                                string door_188 = "- На самом деле мне все равно, что смотреть. Мне нравится сама атмосфера, запись с пленки, запах попкорна… Прости, что-то я заговорилась. Наверное это все глупо звучит.";
                                string door_189 = "- Совсем нет.";
                                string door_190 = "- Правда?";
                                string door_191 = "- Правда. Как можно считать, что человек говорит глупости, когда он рассказывает о том, что любит?";
                                string door_192 = "<i>Алена покраснела вновь. На самом деле это случалось так часто, что, в конце концов, я просто перестал замечать.</i>";
                                string door_193 = "<i>Когда мы пошли в кино, Алена вела себя странно. Даже не знаю, чем это объяснить. Она не смотрела на меня, а стоило мне взглянуть на нее, как тут же вздрагивала и заливалась краской.\n\nЯ подумал, что это из-за Вани, поэтому во время фильма взял ее за руку и не отпускал до самого конца. \n\nДомой мы возвращались поздним вечером…</i>";
                                string door_194 = "<i>Поднимаясь по ступенькам в полной тишине, никто из нас не решался ее нарушить. Я открыл дверь перед ней, пропуская внутрь.Наши комнаты были напротив друг друга и, когда пришло время расходиться, Алена легонько придержала меня за футболку. Я обернулся.</i>";
                                string door_195 = "- Что-то не так?";
                                string door_196 = "- Б-братик, не оставляй меня сегодня, пожалуйста…";
                                string door_197 = "- Но ведь…";
                                string door_198 = "- Пожалуйста…";
                                string door_199 = "<i>Алена смотрела на меня умоляюще, чуть не плача. Я снова не смог ей отказать.</i>";
                                string door_1100 = "- Поспи со мной. Только эту ночь…";
                                string door_1101 = "- Хорошо. Только если ты пообещаешь мне больше не плакать.";
                                string door_1102 = "<i>Сестра улыбнулась и кивнула.</i>";
                                string door_1103 = "<i>В ее комнате повсюду были развешаны плакаты различных рок-групп. На полке стояло несколько небольших рамок с фотографиями, но в целом царила практически идеальная чистота.</i>";
                                string door_1104 = "- Ого, не то, что у меня…";
                                string door_1105 = "- Я просто убираюсь чаще.";
                                string door_1106 = "<i>Мы по очереди приняли душ и легли на разные концы кровати. Я старался не думать ни о чем, и мне с трудом это удавалось, ровно до тех пор, пока Алена не обняла меня.</i>";
                                string door_1107 = "- Братик, ты спишь?";
                                string door_1108 = "<i>Я понимал, что нужно соврать, но не смог.</i>";
                                string door_1109 = "- Нет.";
                                string door_1110 = "<i>Несмотря на весь здравый смысл, я обернулся к ней, и она в тот же миг накрыла мои губы поцелуем.</i>";
                                string door_1111 = "- Ален, это неправильно. Мы – брат и сестра. Все-таки это была не лучшая идея. Прости… Мне стоит уйти… -<i> и я действительно ушел. Она не стала меня останавливать</i>.";
                                string door_1112 = "<i>На следующий день я решил поговорить с Иваном по-мужски. Попросил у Алены его номер и договорился о встрече.\n\nОн оказался чуть ли не в три раза больше меня.\n\nИнстинкт самозащиты просто кричал о том, что я не выстою против него.</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_19, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_110, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_111, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_112, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_113, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_114, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_115, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_116, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_117, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_118, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_119, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_120, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_121, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_122, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_123, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_124, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_125, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_126, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_127, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_128, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_129, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_130, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_131, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_132, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_133, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_134, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_135, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_136, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_137, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_138, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_139, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_140, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_141, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_142, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_143, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_144, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_145, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_146, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_147, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_148, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_149, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_150, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_151, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_152, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_153, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_154, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_155, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_156, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_157, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_158, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_159, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_160, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_161, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_162, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_163, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_164, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_165, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_166, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_167, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_168, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_169, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_170, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_171, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_172, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_173, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_174, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_175, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_176, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_177, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_178, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_179, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_180, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_181, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_182, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_183, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_184, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_185, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_186, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_187, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_188, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_189, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_190, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_191, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_192, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_193, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_194, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_195, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_196, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_197, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_198, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_199, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1100, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1101, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1102, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1103, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1104, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1105, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1106, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1107, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1108, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1109, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1110, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1111, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);

                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Заступиться за сестру"),


                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Уйти"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Поговорить"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                //keyboardLast = keyboard;
                                string[] keys = {"Заступиться за сестру", "Уйти", "Поговорить" , "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1112, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);

                            }
                            else if (message.Text == "Заступиться за сестру")
                            {
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Ожидайте загрузки текста"),
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                string door_1113 = "<i>Наверное, я совсем сошел с ума, но я не мог оставить все, как было. Естественно, в драке я не победил. На самом деле Ваня  как следует отделал меня. Не помню, когда отключился.\n\nОчнулся в больнице совсем без сил. Первым, что я увидел по пробуждению, была она… Алена плакала и смотрела на меня, долго спрашивала, как я себя чувствую, а затем, успокоившись, попросила медсестру оставить нас наедине, после чего заперла дверь на ключ</i>.";
                                string door_1114 = "- Миш… Ты не должен был… Я… Прости… Я чувствую себя виноватой за то, что случилось с тобой.";
                                string door_1115 = "- Успокойся, это не твоя вина. Кто-то должен был это сделать. Он не имеет права так поступать с тобой.";
                                string door_1116 = "- Я рассталась с ним… До сих пор у меня не хватало смелости, но после того, что он сделал с тобой, я больше не могла молчать. Все то, что копилось долгие месяцы, вырвалось наружу.";
                                string door_1117 = "- Теперь все будет хорошо.";
                                string door_1118 = "<i>Я взял ее за руку и она улыбнулась сквозь слезы, кивнув мне.</i>";
                                string door_1119 = "- Да…";
                                string door_1120 = "Постельная сцена\n\n<i>Сказать, что мне было стыдно – значит ничего не сказать. Стыдно перед Аленой, перед собой, но больше всего перед родителями.\n\nПосле всего, что произошло, мне не оставалось другого выбора, кроме как рассказать обо всем родителям и взять на себя всю ответственность…\n\nОказалось, что мы с Аленой – не родные брат и сестра. Ее родители дружили с моими. Потом случилась авария. Тогда малышка осиротела. Они не могли оставить ее в приюте.\n\nЧестно говоря, эта новость меня обрадовала, сняла гору с плеч.\n\nМама сказала, что теперь все будет иначе.</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1113, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1114, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1115, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1116, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1117, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1118, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1119, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1120, false, false, 0, keyboardDoor2, ParseMode.Html); Thread.Sleep(4000);
                                //keyboardLast = keyboardDoor2;
                                string[] keys = { "Войти во вторую дверь", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            else if (message.Text == "Уйти")
                            {
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Ожидайте загрузки текста"),
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                string door_1121 = "<i>Я ничего не мог сделать. Мне оставалось только уйти, поджав хвост…\n\nНа следующий день они помирились.\n\nЧерез неделю сестра сказала мне, что беременна от Ивана. Она плакала всю ночь. Ни я, ни мама не могли успокоить ее.\n\nСегодня он переезжает к нам. Я обещал помочь с коробками. Но, поднимаясь по лестнице, я почувствовал, что что-то не так.\n\nСтены, окружающие меня предметы и люди – все это начало таять, как мороженное в жару.\n\nЯ снова очнулся в той комнате с дверями.\n\nНаверное стоило вернуться, нехорошо было оставлять сестру одну, но я не мог. Что-то неведомое мешало мне, заставляло продолжать путь. Я поклялся себе, что вернусь сюда, когда вспомню все…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1121, false, false, 0, keyboardDoor2, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Войти во вторую дверь", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            else if (message.Text == "Поговорить")
                            {
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Ожидайте загрузки текста"),
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                string door_1123 = "- Ты – Иван, верно?";
                                string door_1124 = "<i>Он окинул меня презрительным взглядом.</i>";
                                string door_1125 = "- Что тебе нужно?";
                                string door_1126 = "- Я хотел поговорить с тобой о моей сестре. Я понимаю, что ты чуть ли не в десяток раз сильнее меня и против тебя я ничего сделать не могу, поэтому не собираюсь драться, но и оставить все, как есть, не могу.";
                                string door_1127 = "<i>Громила скрестил руки на груди.</i>";
                                string door_1128 = "- И чего ты хочешь?";
                                string door_1129 = "- Она все время плачет из-за тебя. Из-за того, что вы ругаетесь. Разве ты не любишь ее?";
                                string door_1130 = "<i>Иван опустил взгляд.</i>";
                                string door_1131 = "- Люблю. Но она постоянно спорит со мной. Я понимаю, что она гораздо умнее меня… Чувствую себя жалким… Думаю поэтому я и срываюсь на нее.";
                                string door_1132 = "<i>Я тяжело вздохнул. Он согласился на диалог, и то хорошо.</i>";
                                string door_1133 = "- Послушай. Ты не жалок из-за того, что Алена умнее тебя. Ты жалок, когда обижаешь ее, понимаешь? Настоящие мужчины себя так не ведут. Если продолжишь – потеряешь ее навсегда.";
                                string door_1134 = "<i>Я развернулся, собираясь уйти, но Иван остановил меня. Я уже был готов отправиться в нокаут и зажмурился, ожидая удара, но он лишь похлопал меня по плечу.</i>";
                                string door_1135 = "- А ты хороший парень, хоть и слабый. Честно, ты мне раньше не нравился. Ну, не по душе мне такие люди, но я ошибся. Я постараюсь больше не обижать твою сестру.";
                                string door_1136 = "- Спасибо. Надеюсь она больше не будет плакать. Больно видеть ее такой.";
                                string door_1137 = "- И мне…";
                                string door_1138 = "<i>Они действительно помирились.\n\nУзнав о том, что я поговорил с Иваном, Алена очень удивилась, а потом  поблагодарила меня. Думаю теперь у нее все наладится…\n\nВдруг стены, окружающие меня предметы и люди – все это начало таять, как мороженное в жару.\n\nЯ снова очнулся в той комнате с дверями.\n\nНаверное стоило вернуться, нехорошо было оставлять сестру одну, но я чувствовал, что больше не нужен здесь. Я должен продолжить свой путь…</i>";

                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1123, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1124, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1125, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1126, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1127, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1128, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1129, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1130, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1131, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1132, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1133, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1134, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1135, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1136, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1137, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_1138, false, false, 0, keyboardDoor2, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Войти во вторую дверь", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            else if (message.Text == "Авторы" || message.Text == "авторы")
                            {

                                await Bot.SendPhotoAsync(message.Chat.Id, "https://preview.ibb.co/gsmpCR/pasha.jpg", "Вы нашли пасхалочку, заботливо подготовленную для Вас авторами. \n\nМы, Amadei, Znahar");
                            }

                            else if (message.Text == "/help")
                            {
                                List<string> a = new List<string>();
                                a = Keys_out_file(message.Chat.Id);
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                if (a.Count == 1)
                                {
                                    keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                        ResizeKeyboard = true
                                    };
                                }
                                else if (a.Count == 2)
                                {
                                    keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                        ResizeKeyboard = true
                                    };
                                }
                                else if (a.Count == 3)
                                {
                                    keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[2])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                        ResizeKeyboard = true
                                    };
                                }
                                else if (a.Count == 4)
                                {
                                    keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[2])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[3])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                        ResizeKeyboard = true
                                    };
                                }
                                else if (a.Count == 5)
                                {
                                    keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[2])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[3])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[4])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                        ResizeKeyboard = true
                                    };
                                }

                                else if (a.Count == 6)
                                {
                                    keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[2])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[3])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[4])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[5])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                        ResizeKeyboard = true
                                    };
                                }
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Этот бот служит для игрового процесса в текствовoм квесте, в чате ничего не пишите что бы не спойлерить себе игру, читайте текст, и ждите кнопок", false, false, 0, keyboard, Telegram.Bot.Types.Enums.ParseMode.Default);
                            }

                            //дверь №2
                            else if (message.Text == "Войти во вторую дверь")
                            {

                                string door_20 = "<i>Я вновь был в той круглой комнате.\n\nНа данный момент моей единственной зацепкой были голубые волосы с фотографии. Я намеревался это исправить.\n\nПоднявшись на ноги, я направился к следующей двери. Она была выполнена на манер средневековой Англии. Не знаю, откуда я могу помнить про Англию и другие очевидные вещи. Мне очень повезло, что утрата памяти была частичной. В противном случае я ничем не отличался бы от овоща.\n\nВзяв себя в руки, я открыл ее и тут же понял, что все идет не так.\n\nЯ несся на огромной скорости по какой-то трубе, наполненной водой. Нет, это не была обычная труба. В ней было достаточно места, Я мог дышать и двигаться, вот только совершенно ничего не видел.\n\nПотом все закончилось. Я больше не чувствовал ничего под собой. Выбравшись из так называемой «трубы», я оказался ослеплен ярким солнечным светом, мне казалось, что я лечу. Какое-то время так и было. Но мне понадобилась не одна секунда на то, чтобы осознать, что лечу я вниз.\n\nПослышался всплеск – это я ударился о водяную гладь\n\n. Хорошо, что лететь было не высоко. В противном случае приземление не было бы столь удачным.</i>";
                                string door_21 = "<i>Я в один миг оказался в воде и тут же всплыл на поверхность, подобно резиновому мячу.\n\nОт неожиданности я чуть не захлебнулся.</i>";
                                string door_22 = "- Ты в порядке? –<i> кто-то протянул мне руку. Это была шикарная голубоглазая блондинка.</i>";
                                string door_23 = "- Вы кто? – <i>спросил я, не решаясь обратиться к ней на «ты».</i>";
                                string door_24 = "<i>Девушка мгновенно рассмеялась, по-видимому, не приняла моих слов всерьез.</i>";
                                string door_25 = "- Очень смешно, Миш. Ладно. Выбирайся. Простудишься еще.";
                                string door_26 = "<i>Я решил, что не стоит повторять былых ошибок. Все же у врача я был и мне сказали, что видимых травм у меня не наблюдается. Что бы ни служило причиной моей амнезии, это не ускорит процесс восстановления памяти, а возможно и наоборот, замедлит ее.  Лучше помалкивать и наблюдать за происходящим. Поэтому я просто кивнул и вылез из бассейна.\n\nСначала я подумал, что нахожусь в каком-нибудь аквапарке, но это было не так. Настоящий бассейн с водяной горкой находился прямо в ее дворе.\n\nХорошо бы узнать ее имя, но так, чтобы не вызвать подозрений. Пока же все, что мне известно – она красивая и богатая.\n\nМы вошли в дом, который размерами своими был сопоставим с какими-нибудь старинными английскими усадьбами.\n\nНе удивительно, что дверь в этот мир была именно такой.\n\nА отдельный ли это мир? Полагаю да. У меня было чувство, что за каждой из тех дверей находится своя альтернативная реальность. Так почему же я могу спокойно перемещаться между ними? И остаюсь ли я собой в каждом из этих миров?..</i>";
                                string door_27 = "- О чем задумался?";
                                string door_28 = "- Сколько лет прошло с нашего знакомства?";
                                string door_29 = "<i>Она задумалась, словно вспоминая.</i>";
                                string door_210 = "- Много лет. Кажется с самого детства. Честно говоря, это было так давно, что я уже и вспомнить, наверное, не смогу.";
                                string door_211 = "<i>Значит я не ошибся.</i>";
                                string door_212 = "- С чего вдруг ты решил заговорить о прошлом?";
                                string door_213 = "- Сам не знаю. Просто иногда накатывают воспоминания. С тобой такое случается?";
                                string door_214 = "- Конечно, я ведь тоже человек. Мы столько лет дружили с тобой… Даже не верится, что ты осмелел и предложил мне встречаться. Ты всегда был таким нерешительным. Это даже мило.";
                                string door_215 = "- И почему ты согласилась? ";
                                string door_216 = "- Не знаю… На самом деле ты единственный, к кому я чувствую теплоту. Мои родители всегда говорили, что самые крепкие браки – те, что держатся на дружбе, -<i> заговорив о семье, она густо покраснела,</i> - Прости. Ты знаешь, я ведь ничего такого не имею в виду…";
                                string door_217 = "- Похоже, это многое значит для тебя, я прав?";
                                string door_218 = "<i>Девушка отвела взгляд к окну.</i>";
                                string door_219 = "- Я всегда любила смотреть на моих родителей. Такие любящие и счастливые… Интересно, будет ли у меня такая же семья? Своя, собственная?.. Я пока не до конца разобралась в себе, но, если бы у меня было такое будущее, я бы ни о чем не жалела…";
                                string door_220 = "<i>Я положил руку на ее плече.</i>";
                                string door_221 = "- Когда-нибудь обязательно будет.";
                                string door_222 = "<i>Она улыбнулась.</i>";
                                string door_223 = "-Ты прав. Однажды… Возможно даже с тобой.";
                                string door_224 = "<i>Эти слова заставили меня подавиться слюной. Ее это позабавило.</i>";
                                string door_225 = "- Прости. Ты ведь совсем не изменился. Всегда так смущаешься и краснеешь. Это я и люблю в тебе. ";
                                string door_226 = "- Разве в этом есть что-то особенное?";
                                string door_227 = "- И да, и нет.  Сейчас многие парни стесняются этого. Они боятся выглядеть не круто. Ты не такой, как они. Ты настоящий. Не теряй этого.";
                                string door_228 = "- Хорошо.";
                                string door_229 = "<i>Мы еще посидели какое-то время у бассейна, безмолвно наблюдая за тем, как колышется вода от малейшего дуновения ветерка. Неожиданно в него упала капля, затем еще одна и еще. Небо медленно заполняли тучи.</i>";
                                string door_230 = "- Кажется нам лучше вернуться в дом. Здесь становится прохладно…";
                                string door_231 = "<i>И правда. Ветер становился все сильнее и порывистей. Капли с новой силой били по телу.\n\nЕще немного и один из нас бы точно заболел.\n\nМы прошли в дом, и я едва не закричал от восторга. Если снаружи он казался большим, то внутри оказался просто огромным. Стены, потолки – все это казалось чем-то недостижимым.\n\nЯ словно находился в музее. И там, и тут можно было увидеть различные картины, статуи, вазы, да и сама обстановка была, как в старинных поместьях. От всего окружающего было невозможно оторвать глаз…\n\nМеня отвлек ее голос.</i>";
                                string door_232 = "- Поражает, верно? ";
                                string door_233 = "- Что?";
                                string door_234 = "- Мама столько лет занималась домом, покупала все это, чтобы я культурно развивалась. Глупо, наверное, звучит. Думаю, ей просто хотелось иметь свою галерею.";
                                string door_235 = "- Наверное… Но это правда потрясающе! Прямо дух захватывает.";
                                string door_236 = "- Да, но… Он все меньше походит на дом. Конечно, мы можем себе это позволить, но это все так бессмысленно… Величие делает этот дом еще более пустым.";
                                string door_237 = "- Я не думал об этом…";
                                string door_238 = "<i>Она выглядела грустной. Кажется это очень важно для нее.</i>";
                                string door_239 = "- Ты… всегда был добр ко мне… Знаешь, я пыталась ходить в специальную школу для богатых семей, но не смогла. Все там… Учителя, другие работники, даже дети… У всех тот страшный взгляд…";
                                string door_240 = "- «Страшный взгляд»?..";
                                string door_241 = "- Да… Улыбки, добродушие – за всем этим скрывались ужасные монстры. В конце концов оставаться там было невыносимо. Меня перевели в обычную школу, но даже там я видела их… Ты был другим. Тебе было не важно ни кто я, ни сколько у меня денег. Ты просто был добр ко мне. Тебе не было нужно ничего. Все, что ты хотел – это помочь…";
                                string door_242 = "<i>Я промолчал.</i>";
                                string door_243 = "- Помнишь день нашей встречи?";
                                string door_244 = "<i>Я виновато опустил глаза. Нет. Я не могу рассказать ей о том, что потерял память.</i>";
                                string door_245 = "- Нет… Конечно нет… Ты и не можешь помнить этого. Это было так давно…";
                                string door_246 = "- Прости.";
                                string door_247 = "- Да нет, ничего. Для тебя это, наверное, один из обычных дней, но я никогда не забуду его… То, как ты спас меня от тех девчонок… Я так испугалась, что убежала и долго-долго плакала, а ты пошел за мной…";
                                string door_248 = "- Я не мог пройти мимо. Тебе ведь было нужно, чтобы тебя кто-то поддержал.";
                                string door_249 = "- Только ты был готов заступиться за меня. Даже когда с тобой все перестали разговаривать, ты сказал, что  все в порядке, пока я не плачу…";
                                string door_250 = "<i>Ее воспоминания вызывали множество чувств даже у меня. Пусть я и не помнил всего, но это не мешало мне чувствовать.\n\nТогда я обнял ее. Не знаю почему. Для меня она была никем. Я не знал ее имени, я не помнил ни ее, ни того времени, которое она провела со мной. Но, в то же время, я не мог назвать ее чужой. Что-то глубоко внутри мешало мне.\n\nОна обняла меня в ответ.\n\nНе знаю, сколько мы простояли так, до тех пор, пока она не решилась отстраниться.</i>";
                                string door_251 = "- Прости, я совсем забыла о завтраке. Пойдем, я приготовлю что-нибудь…";
                                string door_252 = "- Странно, что в таком громадном доме нет прислуги.";
                                string door_253 = "- Да, я тоже иногда думаю об этом, но мне приятно самой заниматься хозяйскими делами. Не хочу доверять работу, которую могу выполнить сама, кому-то еще.";
                                string door_254 = "- Ты слишком много задумываешься над этим.";
                                string door_255 = "- Наверное, ты прав.";
                                string door_256 = "<i>Она рассмеялась вновь. В тот момент что-то мелькнуло у меня в голове.\n\nЯ был на детской площадке. Она качалась на качели с какой-то девочкой с зелеными волосами. Я позвал ее и она обернулась.\n\nИрина! Так вот, как ее зовут! И та девочка… С зелеными волосами… Почему мне кажется это важным?..</i>";
                                string door_257 = "- Ира, скажи…";
                                string door_258 = "- Да?";
                                string door_259 = "- Я вдруг просто вспомнил… Когда-то давно… Ты качалась на качели с одной девочкой… У нее еще были зеленые волосы… Ты не помнишь ее?";
                                string door_260 = "<i>Она выглядела задумчиво.</i>";
                                string door_261 = "- Зеленые волосы?..";
                                string door_262 = "- Ну как? Вспомнила что-нибудь?";
                                string door_263 = "- Нет, прости.  Я правда не помню ничего подобного. На самом деле я не помню, чтобы видела кого-нибудь с зелеными волосами где-нибудь, кроме картинок.";
                                string door_264 = "- Вот как… ";
                                string door_265 = "<i>Я тяжело вздохнул. Снова мои воспоминания ни к чему не привели.</i>";
                                string door_266 = "- Все хорошо? Ты такой задумчивый в последнее время…";
                                string door_267 = "- Да… Просто много чего случилось… Не бери в голову.";
                                string door_268 = "- Хорошо… Спасибо тебе, что согласился провести все это время со мной. Это правда важно для меня.";
                                string door_269 = "- Кстати говоря. Почему ты вдруг попросила об этом?";
                                string door_270 = "<i>Она замялась. Этого нельзя было не заметить. Ирина тут же изменилась в лице.\n\nЧто-то было не так…</i>";
                                string door_271 = "- Миш… Я давно хотела тебе сказать… Но все никак не могла решиться… Родители хотят забрать меня в Лондон через неделю…";
                                string door_272 = "- Это же здорово!";
                                string door_273 = "<i>Ира покачала головой.</i>";
                                string door_274 = "- Ты не понял, Миш. Они хотят забрать меня насовсем… Не думаю, что я когда-нибудь вернусь сюда… Боюсь, мы больше никогда не увидимся.";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_20, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_21, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_22, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_23, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_24, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_25, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_26, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_27, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_28, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_29, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_210, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_211, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_212, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_213, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_214, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_215, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_216, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_217, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_218, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_219, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_220, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_221, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_222, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_223, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_224, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_225, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_226, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_227, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_228, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_229, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_230, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_231, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_232, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_233, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_234, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_235, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_236, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_237, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_238, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_239, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_240, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_241, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_242, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_243, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_244, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_245, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_246, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_247, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_248, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_249, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_250, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_251, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_252, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_253, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_254, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_255, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_256, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_257, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_258, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_259, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_260, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_261, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_262, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_263, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_264, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_265, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_266, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_267, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_268, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_269, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_270, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_271, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_272, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_273, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Остановить"),


                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Согласиться"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Отказаться"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Отпустить"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                string[] keys = { "Остановить", "Согласиться", "Отказаться", "Отпустить", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_274, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);

                            }
                            else if (message.Text == "Остановить")
                            {
                                string door_276 = "- Разве ты хочешь этого?";
                                string door_277 = "- Что? Нет! Конечно не хочу! Но… Что я могу? ";
                                string door_278 = "- Скажи им, что хочешь остаться, что не хочешь уезжать. Ты уже совершеннолетняя, ты можешь жить здесь и одна.";
                                string door_279 = "- Они против этого… Считают, опасно оставлять меня одну здесь.";
                                string door_280 = "- Но ты ведь не одна здесь. У тебя есть я.";
                                string door_281 = "- Ты прав… Возможно, если бы ты поговорил с ними, они позволили бы мне остаться здесь… Но… Ты правда пойдешь на это?...";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_276, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_277, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_278, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_279, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_280, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Остановить", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_281, false, false, 0, keyboardDoor3, ParseMode.Html); Thread.Sleep(4000);
                                
                            }
                            else if (message.Text == "Согласиться")
                            {
                                string door_282 = "- А почему нет? Глупо не попытаться…";
                                string door_283 = "<i>Вечером мы пили чай в напряженном молчании, дожидаясь возвращения ее родителей. Я не знал, получится ли у меня, но попробовать стоило.\n\nРазговор был долгим и тяжелым. Они оба выслушали меня, сопоставив все «за» и «против». Отец Иры долго буравил меня взглядом, но я держался. Я ведь действительно не собирался причинять ей зло.\n\nВ конце концов, после нашего разговора, они не остыли полностью, но попробовать согласились.\n\nИрина останется здесь на месяц и, если не будет никаких проблем, она сможет и дальше жить здесь.\n\nКогда родители ушли вновь, Ира радостно кинулась мне на шею.</i>";
                                string door_284 = "- Слава Богу! Господи, Миш, как же я рада! Спасибо тебе!";
                                string door_285 = "- Ладно тебе. Все уже позади. Рада, что остаешься?";
                                string door_286 = "- Очень! Очень рада! Спасибо тебе огромное!";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_282, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_283, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_284, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_285, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_286, false, false, 0, keyboardDoor3, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Согласиться", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            else if (message.Text == "Отказаться")
                            {
                                string door_287 = "- Ир, это твоя жизнь. Твои родители должны понять тебя, но для этого тебе нужно поговорить с ними. Покажи им, что ты способна самостоятельно принимать решения.";
                                string door_288 = "- Наверное ты прав… Я слишком часто полагалась на тебя…";
                                string door_289 = "- Дело не в этом. Ира, ты сильная, сильнее, чем думаешь. Не хватает лишь веры в себя. Понимаешь? ";
                                string door_290 = "<i>Она грустно посмотрела на меня.</i>";
                                string door_291 = "- Не знаю, получится ли у меня…";
                                string door_292 = "- Обязательно получится.";
                                string door_293 = "<i>Родители поняли ее.\n\nВ конце концов, после бесконечных уговоров, установив кучу правил и условий, они согласились оставить ее в городе.\n\nДумаю это было правильным решением… </i>";
                                string door_294 = "<i>На следующий день мы поехали куда-то. Ирина не сказала куда. Наверное готовила сюрприз. Но нам было не суждено доехать.\n\nНа одном из сложных поворотов случилась авария, Ира не справилась с управлением. Машина перевернулась.\n\nЯ почувствовал, что выпадаю из реальности. Подобные ощущения люди испытывают при пробуждении. Но, что-то мне подсказывало, что я не сплю. Люди не могут спать так долго…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_287, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_288, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_289, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_290, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_291, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_292, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_293, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_294, false, false, 0, keyboardDoor3, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Отказаться", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            else if (message.Text == "Отпустить")
                            {
                                string door_296 = "- С чего ты взяла? Мы еще обязательно встретимся. Я могу приезжать к тебе, а ты ко мне. Сейчас рейсы летают практически каждый день.";
                                string door_297 = "<i>Ирина заплакала.</i>";
                                string door_298 = "- Просто… Так грустно улетать… Я не хочу оставлять тебя. Не хочу, чтобы ты меня забывал, чтобы забыл все это…";
                                string door_299 = "- Я не забуду. Обещаю.";
                                string door_2100 = "<i>Только не снова.</i>";
                                string door_2101 = "- Правда?";
                                string door_2102 = "- Правда.";
                                string door_2103 = "<i>Я легонько провел по ее щеке, вытирая слезу.</i>";
                                string door_2104 = "- Миш… Миш, поцелуй меня, пожалуйста… Я знаю, это глупо… но… Я не знаю, когда смогу увидеть тебя, услышать тебя и прикоснуться к тебе вновь… Сейчас, пока я здесь, я хочу чувствовать тебя…";
                                string door_2105 = "<i>И мы поцеловались.</i>";
                                string door_2106 = "*Постельная сцена*";
                                string door_2107 = "<i>Когда Ирина уехала, я почувствовал, что выпадаю из реальности. Подобные ощущения люди испытывают при пробуждении. Но, что-то мне подсказывало, что я не сплю. Люди не могут спать так долго…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_296, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_297, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_298, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_299, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_2100, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_2101, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_2102, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_2103, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_2104, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_2105, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_2106, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_2107, false, false, 0, keyboardDoor3, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Отпустить", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            //дверь №3
                            else if (message.Text == "Войти в третью дверь")
                            {
                                string door_30 = "<i>Каждая дверь в этой комнате отличалась уникальностью, но следующая дверь, которую я намеревался открыть, выделялась среди них наличием граффити, довольно качественно выполненным на металлической основе, и все же. Что же меня ждет?..</i>";
                                string door_31 = "<i>Я проснулся оттого, что в комнату пробился яркий  солнечный свет. Потянувшись, я подошел к окну и распахнул его. В лицо тут же ударил свежий морозный воздух. За окном, кружась, падали большие хлопья снега.\n\nНаверное это действительно разные миры. Даже время в них течет иначе. До сих пор я был уверен в том, что сейчас лето, но погода за окном указывала на обратное.\n\nГлядя на заснеженный двор, я начал что-то вспоминать. Что-то важное, связанное с зимой…\n\nЯ видел девочку с волосами цвета снега, сидящую у камина. Она напевала какую-то тихую мелодию. Лишь она, потрескивание камина и размеренное тиканье часов нарушали эту тишину… \n\nНо, стоило мне подойти ближе, как видение рассеялось. Не было ни девочки, ни песни, ни камина…</i>";
                                string door_32 = "<i>На сей раз я действительно очнулся, но за окном не было снега.\n\nНеужели приснилось?..</i>";
                                string door_33 = "- Братик, ты скоро там? – раздался голос за дверью.";
                                string door_34 = "<i>Без сомнений, это была Алена.\n\nПеред глазами начали проплывать воспоминания, но я тут же от них отмахнулся.\n\nЕсли миры разные, то и люди, которых я встречал, везде разные. Однако она все еще моя сестра. Нужно вести себя, словно ничего не случилось.</i>";
                                string door_35 = "- Только встал. Погоди, соберусь и спущусь.";
                                string door_36 = "- Блииин. Как ты можешь так долго спать? Мы ведь договаривались, я обещала Ане, что не буду опаздывать…";
                                string door_37 = "- Прости. В следующий раз разбуди меня.";
                                string door_38 = "- Легко сказать… Братик, ты спишь, как медведь зимой. Чтобы тебя разбудить, нужно еще постараться.";
                                string door_39 = "<i>Я рассмеялся.</i>";
                                string door_310 = "- Ладно, не дуйся, я быстро.";
                                string door_311 = "<i>Я собирался так скоро, как только мог, но Алена продолжала дуться на меня.\n\nМне предстояло вести машину. Видимо свою.</i>";
                                string door_312 = "- Почему застыл? Что-то не так?";
                                string door_313 = "- Да нет…";
                                string door_314 = "<i>Нужно было взять себя в руки. Пока все, что я забыл, касалось только окружающих  людей и всего, что с ними связано.\n\nНо тревога не покидала меня. Может в этом мире я когда-то и водил машину, но что насчет других? Что, если у меня не выйдет?</i>";
                                string door_315 = "- Ален, я себя чувствую не очень… Может ты сядешь за руль?";
                                string door_316 = "- Что-о?.. Ты издеваешься, братик? Я ведь даже на велосипеде кататься не умею!";
                                string door_317 = "- Прости, просто шучу…";
                                string door_318 = "<i>Выбора не было. Нужно вести машину.\n\nК сожалению, мне не удалось вспомнить ни одной молитвы, а жаль.\n\nЯ был на грани того, чтобы попрощаться с жизнью, но все же справился с управлением.\n\nПо-видимому, какие-то навыки у меня все же были.\n\nНаконец припарковавшись, я облегченно вздохнул, а Алена буквально вылетела из машины. Я последовал за ней.\n\nОна спустилась в какой-то паб.\n\nТам было на удивление пусто, лишь занят один столик в углу. Там сидела девушка. У нее были длинные русые волосы и серые глаза. У нее в руках было что-то вроде книги, но, увидев нас, она в мгновение ока захлопнула ее и сунула в рюкзак.</i>";
                                string door_319 = "- Вы опоздали. Снова.";
                                string door_320 = "<i>Кажется она была очень недовольна этим фактом.\n\nАлена тут же принялась извиняться.</i>";
                                string door_321 = "- Прости пожалуйста. Я пыталась его разбудить, но ты ведь знаешь, какой братец неподъемный…";
                                string door_322 = "- Ты обещала.";
                                string door_323 = "- Прости! – <i>сестра сложила ладони и поклонилась в знак извинения.</i>";
                                string door_324 = "<i>Девушка шумно выдохнула.</i>";
                                string door_325 = "- Ничего не поделаешь. Мне стоило к этому привыкнуть. Я заказала себе темного пива.";
                                string door_326 = "- Я возьму кофе! Тебе как обычно, братик?";
                                string door_327 = "- Я… Пожалуй тоже кофе…";
                                string door_328 = "<i>Алена уставилась на меня, как на прокаженного. Аня, кажется ее так зовут, только смерила каким-то изучающим взглядом.</i>";
                                string door_329 = "- Что-то не так?";
                                string door_330 = "- Да нет… Просто обычно ты тоже берешь темное пиво… Даже странно… ";
                                string door_331 = "- Не вижу ничего странного, - <i>спокойно ответил я.</i>";
                                string door_332 = "<i>Честно говоря, в пабе ничего особенного не произошло. Они практически не разговаривали, сестра чувствовала себя неловко.\n\nМне понравилось там. Тихое уютное место. Можно посидеть, подумать… Думаю поэтому я вновь вернулся туда.\n\nНо на сей раз здесь не было так тихо. Паб был полон людей, и практически все столы заняты. Я собирался развернуться и уйти, но услышал знакомый голос. В углу, за тем самым столиком сидела Аня. Над ней нависал какой-то мужик.</i>";
                                string door_333 = "- Как ты смеешь отказывать мне?! Да ты хоть знаешь, кто я такой?! ";
                                string door_334 = "- Очередной пьяница из паба. Иди своей дорогой, пока не получил.";
                                string door_335 = "- А ты смелая для соплячки! Зря, очень зря ты пришла сюда одна!";
                                string door_336 = "<i>Больше я не мог оставаться в стороне.</i>";
                                string door_337 = "- А кто сказал, что она одна?";
                                string door_338 = "- Миша?.. –<i> она подняла полный удивления взгляд на меня.</i>";
                                string door_339 = "<i>Я улыбнулся.</i>";
                                string door_340 = "- Прости, я снова опоздал.";
                                string door_341 = "<i>Но громила не собирался так запросто уходить.</i>";
                                string door_342 = "- Ты кто вообще такой?!";
                                string door_343 = "- Я – ее друг. А вот кто ты – вопрос. ";
                                string door_344 = "- На драку нарываешься?! ";
                                string door_345 = "<i>Я поморщился от запаха алкоголя и пота.</i>";
                                string door_346 = "- Здесь много людей, а неприятности доставляешь только ты. Бармен уже вызвал охрану. На твоем месте я бы успокоился и тихо ушел.";
                                string door_347 = "- Да что ты себе возомнил, засранец?!";
                                string door_348 = "<i>Он еще какое-то время сверлил меня недобрым взглядом, а затем просто развернулся и ушел.</i>";
                                string door_349 = "- Пронесло… Тебе стоило быть осторожнее. Что ты здесь делаешь одна?";
                                string door_350 = "- Пришла побыть наедине с собой, как и ты. Не знала, что здесь будет так много народа.";
                                string door_351 = "- Тебе не стоило поступать так опрометчиво.  Девушке находиться в подобном месте одной небезопасно. Что бы ты сделала, не будь здесь меня?";
                                string door_352 = "- Ничего. Как ты и сказал, бармен действительно вызвал охрану. От этого придурка было слишком много шума.";
                                string door_353 = "<i>Я тяжело вздохнул. Не похоже, чтобы ей было страшно.</i>";
                                string door_354 = "- А ты очень смелая.";
                                string door_355 = "- Да нет. Просто бесят такие люди. Он жалок, поэтому не стоит моего страха. Так или иначе, тебе было необязательно вступаться за меня…";
                                string door_356 = "- Можно я сяду с тобой?";
                                string door_357 = "<i>Она кивнула.\n\nЗаняв место напротив нее, я вновь заметил ту книгу. Она оказалась альбомом.</i>";
                                string door_358 = "- Там рисунки?";
                                string door_359 = "- Секрет.";
                                string door_360 = "- Покажешь? ";
                                string door_361 = "<i>Она помотала головой.</i>";
                                string door_362 = "- Ничего не поделаешь… Чего хотел от тебя тот пьяница?";
                                string door_363 = "- Чтобы я заняла ему денег.";
                                string door_364 = "- Вот как…";
                                string door_365 = "<i>Ну слава Богу. Я думал все намного хуже.\n\nСегодня я вновь заказал кофе. Честно говоря, я впервые пил настолько качественный и вкусный.</i>";
                                string door_366 = "- Нравится? – <i>спросила она.</i>";
                                string door_367 = "- Очень. Попробуй тоже.";
                                string door_368 = "<i>Анна кивнула и заказала такой же для себя.\n\nАльбом так и продолжал лежать на краю стола, до тех пор, пока случайный посетитель не смахнул его на пол. Я тут же наклонился, чтобы поднять его и замер в оцепенении. У меня перед глазами был рисунок той самой беловолосой девочки из воспоминания. Но, увы, я снова не видел ее лица.\n\nОпомнившись, я отдал альбом Ане.</i>";
                                string door_369 = "- Прости, засмотрелся… Ты здорово рисуешь. Можно посмотреть еще?";
                                string door_370 = "<i>Ее щеки мгновенно залил румянец, но она протянула его мне. В нем было множество самых разных рисунков, но только тот был  вырван из альбома.</i>";
                                string door_371 = "- Ты знаешь, это потрясающе! Нет, я серьезно. У тебя самый настоящий талант.";
                                string door_372 = "- Спасибо.";
                                string door_373 = "- Давно рисуешь?";
                                string door_374 = "<i>Анна кивнула.</i>";
                                string door_375 = "- Училась где-то или сама?";
                                string door_376 = "- Сама.";
                                string door_377 = "- Здорово… А я и самое простое нарисовать не в состоянии…";
                                string door_378 = "- Я могу научить, если хочешь.";
                                string door_379 = "- Правда? Было бы круто. Я хотел бы научиться рисовать, как ты…";
                                string door_380 = "- Невозможно. Каждый рисует иначе, потому что видит по-своему.";
                                string door_381 = "- Наверное ты права…";
                                string door_382 = "- Послушай… Скажи… Что это за девушка на рисунке? С белыми волосами.";
                                string door_383 = "<i>Анна выглядела удивленной.</i>";
                                string door_384 = "- Каком рисунке?";
                                string door_385 = "<i>Я ничего не понимал.</i>";
                                string door_386 = "- Вырванном из альбома. Да вот же…";
                                string door_387 = "<i>Я вытащил нужный рисунок из альбома и протянул его ей.</i>";
                                string door_388 = "- Я не рисовала его.";
                                string door_389 = "- Тогда, может ты знаешь кого-то, кто мог это нарисовать?";
                                string door_390 = "<i>Она покачала головой.</i>";
                                string door_391 = "- Исключено, я никому не позволяю притрагиваться к моему альбому.";
                                string door_392 = "- Но тогда откуда он?";
                                string door_393 = "- А мне по чем знать? До сегодняшнего вечера его здесь не было.";
                                string door_394 = "- Тогда… Могу я его забрать?..";
                                string door_395 = "<i>Анна кивнула, протянув рисунок мне. Я сложил лист несколько раз и недолго думая сунул в карман.\n\nПришло время расходиться.</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_30, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_31, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_32, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_33, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_34, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_35, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_36, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_37, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_38, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_39, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_310, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_311, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_312, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_313, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_314, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_315, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_316, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_317, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_318, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_319, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_320, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_321, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_322, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_323, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_324, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_325, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_326, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_327, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_328, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_329, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_330, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_331, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_332, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_333, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_334, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_335, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_336, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_337, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_338, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_339, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_340, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_341, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_342, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_343, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_344, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_345, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_346, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_347, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_348, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_349, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_350, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_351, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_352, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_353, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_354, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_355, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_356, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_357, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_358, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_359, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_360, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_361, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_362, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_363, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_364, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_365, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_366, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_367, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_368, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_369, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_370, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_371, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_372, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_373, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_374, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_375, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_376, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_377, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_378, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_379, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_380, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_381, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_382, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_383, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_384, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_385, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_386, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_387, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_388, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_389, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_390, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_391, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_392, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_393, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_394, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Провести"),

                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Уехать"),
                                                },

                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                string[] keys = { "Войти в третью дверь", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_395, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);
                            }
                            else if (message.Text == "Провести")
                            {
                                string door_396 = "-Знаешь, ты ведь можешь вновь наткнуться на кого-то вроде того негодяя. Не против, если я тебя подвезу?";
                                string door_397 = "<i>Анна какое-то время не отвечала мне.</i>";
                                string door_398 = "- А что насчет моего байка?";
                                string door_399 = "- Я могу проехаться с тобой. Это не займет много времени. Конечно, мне придется возвращаться пешком. Зато мне будет спокойнее, потому что я буду знать, что ты в безопасности.";
                                string door_3100 = "- Ты не обязан это делать.";
                                string door_3101 = "- Да. Но я этого хочу.";
                                string door_3103 = "<i>Что-то заставило ее покраснеть вновь.</i>";
                                string door_3104 = "- Хорошо…";
                                string door_3105 = "<i>За рулем была она. Сначала мне было не по себе от этой идеи, но затем пришло ощущение свободы, когда ты на огромной скорости рассекаешь воздух. У меня попросту захватывало дух.</i>";
                                string door_3106 = "- Это было замечательно! Странно, что я раньше никогда не ездил на байках. Нужно будет обязательно попробовать.";
                                string door_3107 = "- Рада, что тебе понравилось… Но… Ты правда собираешься идти домой пешком?";
                                string door_3108 = "- Да, а что?";
                                string door_3109 = "- На улице уже темно… и холодно… Да и идти очень далеко. Уверен, что не хочешь остаться? Утром доберешься на автобусе или метро.";
                                string door_3110 = "- А ничего, если я останусь? Что скажут твои родители?";
                                string door_3111 = "- Ничего. Их обычно не бывает дома…";
                                string door_3112 = "- Тогда я останусь у тебя до утра, если ты не против.";
                                string door_3113 = "<i>В комнате Анны оказалось множество рисунков и все они были потрясающими. Было видно, что в каждый из них вкладывали душу.\n\nПусть она и выглядит грубой и отстраненной, в ней есть и иная сторона…</i>";
                                string door_3114 = "- Нравится?";
                                string door_3115 = "- Очень… Я и подумать не мог, что ты рисуешь...";
                                string door_3116 = "- Никто и не знает. Никто, кроме тебя… Знаешь, пусть я и не показываю этого, но мне тоже порой бывает страшно… Когда тот громила подошел ко мне, я так испугалась, что хотелось кричать, но что-то внутри запрещало мне делать это, заставляло держаться… Наверное  глупо звучит?";
                                string door_3117 = "- Совсем нет…";
                                string door_3118 = "- Я была рада, когда ты заступился за меня. Обычно люди проходят мимо…";
                                string door_3119 = "- Я подумал, что нельзя оставлять тебя одну в такой ситуации.";
                                string door_3120 = "- Спасибо, что спас меня и проводил… И что не высмеял мои рисунки.";
                                string door_3121 = "- С чего мне их высмеивать? Они потрясающие!";
                                string door_3122 = "<i>Анна грустно улыбнулась.</i>";
                                string door_3123 = "- Ничего не поделаешь. Люди слишком привыкли видеть сильную и грубую оболочку. Я сама в этом виновата. ";
                                string door_3124 = "- Но это ты. Такая, какая есть. Мне кажется это хорошо. Что ты остаешься собой.";
                                string door_3125 = "<i>Не успел я опомниться, как она поцеловала меня.</i>";
                                string door_3126 = "<i>*Постельная сцена*</i>";
                                string door_3127 = "<i>Я снова провалился в сон. Я будто падал в пропасть, которой нет конца, но я уже знал, где очнусь и что увижу…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_396, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_397, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_398, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_399, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3100, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3101, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3103, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3104, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3105, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3106, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3107, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3108, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3109, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3110, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3111, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3112, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3113, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3114, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3115, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3116, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3117, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3118, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3119, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3120, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3121, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3122, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3123, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3124, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3125, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3126, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3127, false, false, 0, keyboardDoor4, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Провести", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            else if (message.Text == "Уехать")
                            {
                                string door_3128 = "- Что ж… Уже довольно поздно. Мне пора возвращаться домой, к сестре. Она будет волноваться.";
                                string door_3129 = "- Да… Я понимаю. Спасибо тебе за сегодня. За то, что спас меня, пусть я и не просила.";
                                string door_3130 = "<i>Я улыбнулся.</i>";
                                string door_3131 = "- Разве я мог поступить иначе?";
                                string door_3132 = "- До встречи.";
                                string door_3133 = "-Пока.";
                                string door_3134 = "<i>Я сел в машину, а она на байк.</i>";
                                string door_3135 = "<i>Утром сестра сказала мне, что Анна попала в аварию и разбилась. Я до сих пор не могу перестать себя винить в ее смерти. Я должен был проводить ее…\n\nЯ снова провалился в сон. Я будто падал в пропасть, которой нет конца, но я уже знал, где очнусь и что увижу…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3128, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3129, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3130, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3131, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3132, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3133, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3134, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_3135, false, false, 0, keyboardDoor4, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Уехать", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            //дверь №4
                            else if (message.Text == "Войти в четвертую дверь")
                            {
                                string door_40 = "<i>Следующая дверь была лилового цвета с выгравированным на ней символом феминистского движения — сжатый кулак (символ борьбы и сопротивления), заключённый в зеркало Венеры (символ женщины).\n\nПодойдя к ней, я едва не поперхнулся.\n\nЭта альтернативная реальность была многообещающей…</i>";
                                string door_41 = "<i>Мой первый день в этой реальности начался никудышно.\n\nВот представьте, сплю я сладким сном, как непонятно откуда прямо в меня прилетает губка для школьной доски.\n\nОт неожиданности я вскочил, повалив на себя несколько вещей с парты.\n\nВ панике оглядываюсь, пытаясь сообразить, что же произошло. Я находился в аудитории. В мою сторону обращены взгляды одногруппников и разъяренного преподавателя.</i>";
                                string door_42 = "- Михаил! Снова спите на моей лекции?! Учтите, не смотря на то, что вы – отличник, с таким отношением автомата вам не видать!";
                                string door_43 = "<i>Отличник? Что ж, неплохо…</i>";
                                string door_44 = "- Уверен, я все сдам, профессор.";
                                string door_45 = "- Не сомневаюсь. Будьте так добры, займите свое место и позвольте мне продолжить лекцию.";
                                string door_46 = "<i>После лекции ко мне подошел какой-то парень. Он был явно выше меня и имел отличительно рыжие кудри.</i>";
                                string door_47 = "- Ну ты чего? Собираешься весь день тут просидеть? Нас уже ребята заждались!";
                                string door_48 = "- Ребята?.. – недоуменно переспросил я.";
                                string door_49 = "- Ну да, Дима и Жанна. Мы ведь договаривались о том, что прогуляемся после занятий. Неужели ты забыл? Планы хоть не изменил?";
                                string door_410 = "- Да нет… Идем…";
                                string door_411 = "<i>На скамейке перед колледжем сидел брюнет в черной толстовке с пентаграммой и девушка с короткими, серыми, как пепел, волосами. У нее были черные глаза.</i>";
                                string door_412 = "- Опаздываете! –<i> возмутилась она.</i>";
                                string door_413 = "- Ничего не поделаешь. Миша снова уснул на лекции.";
                                string door_414 = "<i>Жанна хмыкнула.</i>";
                                string door_415 = "- Что?";
                                string door_416 = "- Ничего, ничего удивительного. Ты ведь парень.";
                                string door_417 = "<i>Я недоуменно посмотрел на нее, а потом на других ребят. Они нервно прикусили губы.</i>";
                                string door_418 = "- Миш, не бери в голову. Жанна, не начинай.";
                                string door_419 = "- Что «Жанна»? Он думает, если он – отличник, ему все позволено? В этом все мужчины!";
                                string door_420 = "- При чем здесь половая принадлежность?";
                                string door_421 = "<i>Я никак не мог выкинуть это из головы. Я хотел понять связь между ее словами.</i>";
                                string door_422 = "- Ничего удивительного, -<i> повторила она. Видимо это была ее любимая фраза.</i>";
                                string door_423 = "<i>А я, тем временем, все еще не понимал.</i>";
                                string door_424 = "- Нет, объясни, -<i> не унимался я.</i>";
                                string door_425 = "- Вот за это я мужиков и ненавижу. Слишком тупые, чтобы понять все с первого раза. Я ухожу.";
                                string door_426 = "<i>Я оглянулся на ребят. Те только нахмурились.</i>";
                                string door_427 = "- Я что-то сделал не так?";
                                string door_428 = "- Нет, -<i> Витя покачал головой. Оказалось, именно так его и звали. Парнем в толстовке был Дима.</i>";
                                string door_429 = "- А что тогда?";
                                string door_430 = "<i>В воздухе повисло напряженное молчание.</i>";
                                string door_431 = "- Она феминистка… К тому же мужененавистница.";
                                string door_432 = "- Но… В нашей компании ведь она – единственная девушка.";
                                string door_433 = "<i>Витя тяжело вздохнул.</i>";
                                string door_434 = "- Это так, но здесь далеко не все так просто… Я – ее брат, ты – мой лучший друг, Дима достаточно неразговорчив и невосприимчив к ее словам, а у нее… у нее совсем нет друзей… Прости. Я должен был сказать тебе заранее. Она со всеми так. Надеюсь ты не держишь на нее зла?";
                                string door_435 = "- С чего бы? ";
                                string door_436 = "- Ну, она ведь тебе нагрубила…";
                                string door_437 = "- Это, конечно, так, но… Я не знаю, за что на нее злиться. Мне просто интересно, с чего вдруг такая нелюбовь к мужчинам?";
                                string door_438 = "<i>Он опустил голову.</i>";
                                string door_439 = "- Я… я думаю, это из-за нашего отца…";
                                string door_440 = "- А что с ним не так?";
                                string door_441 = "- Сколько себя помню, он всегда пил, никогда не имел работы. Мама работала в две смены. У нее никогда не было выходных. Отец всегда кричал на нее и на нас, иногда избивал… Три года назад мама тяжело заболела и умерла…";
                                string door_442 = "- Сочувствую…";
                                string door_443 = "- Спасибо… Жанна очень любила ее и тяжело перенесла ее смерть…";
                                string door_444 = "- И… Вы все еще живете с отцом?";
                                string door_445 = "- Мы стараемся не ночевать дома, но… У меня все еще нет собственной квартиры, а Жанна… Она не ладит практически ни с кем… Я надеялся, что у вас получится поладить, но… Прости, это моя вина.";
                                string door_446 = "- Ты не виноват. Я все понимаю… Ничего страшного.";
                                string door_447 = "- Правда?";
                                string door_448 = "- Да.";
                                string door_449 = "- Тогда… ты все еще не против прогуляться?";
                                string door_450 = "- Конечно нет…";
                                string door_451 = "<i>Оказалось, что мы договорились пойти в центр, посмотреть на выступление Жанны и других уличных танцоров.\n\nЧестно говоря, это было что-то. Даже потеряв память, я могу с полной уверенностью заявить, что никогда не видел ничего подобного вживую.\n\nГромкая зажигательная музыка вибрацией отдавалась по асфальту, а глядя на танцоров хотелось танцевать, но даже не это поразило меня больше всего.\n\nГлядя на то, как танцует Жанна, на то, как она двигается и видя ее замечательную улыбку я не мог связать ее с образом той феминистки, что встретил возле колледжа.\n\nОт мыслей меня отвлек Витя.</i>";
                                string door_452 = "- Здорово, правда?";
                                string door_453 = "- Ты шутишь? Это же потрясающе! Это правда она?";
                                string door_454 = "<i>Он грустно улыбнулся.</i>";
                                string door_455 = "- Раньше Жанна всегда была такой, имела кучу друзей, а сейчас… Сейчас ее можно увидеть такой только когда она танцует…";
                                string door_456 = "- Вот как…";
                                string door_457 = "<i>После выступления мы ждали, пока все разойдутся, чтобы провести Витю и Жанну домой.\n\nОн попытался похвалить сестру, но она лишь огрызнулась.\n\nДумаю, Витя действительно переживает за нее.</i>";
                                string door_458 = "- Ну что, до встречи, друг?";
                                string door_459 = "- До встречи…";
                                string door_460 = "<i>Проведя ребят, остались только мы с Димой. Нам было нужно в одну сторону.\n\nМне было неловко идти в тишине, поэтому я сделал первый шаг к началу разговора.</i>";
                                string door_461 = "- Значит… Ты собираешь всякие амулеты?";
                                string door_462 = "<i>Он молча сунул руку в карман, достав оттуда целую связку различных амулетов.</i>";
                                string door_463 = "- Так и думал…";
                                string door_464 = "<i>Пожав плечами, Дима спрятал их обратно.</i>";
                                string door_465 = "- Почему коллекционируешь?";
                                string door_466 = "- Кто знает… Просто нравятся.";
                                string door_467 = "- Нравятся?";
                                string door_468 = "- Угу.";
                                string door_469 = "- А что ты думаешь о Жанне?";
                                string door_470 = "- Не знаю. Она неплохо танцует. А что?";
                                string door_471 = "- Да нет же. Ну, ты знаешь. О том, что она – феминистка.";
                                string door_472 = "- Ах, ты об этом… Меня это не волнует.";
                                string door_473 = "- Почему?";
                                string door_474 = "- Не знаю, просто не волнует и все. У каждого свои трудности в жизни. Кто-то справляется с ними, кто-то – нет. В любом случае, я не знаю, какого ей было, поэтому не могу судить.";
                                string door_475 = "- Ого…";
                                string door_476 = "- Что? –<i> Дима явно не понял, что меня так удивило.</i>";
                                string door_477 = "- Пока мы были вчетвером, ты все время молчал. Думал ты неразговорчивый.";
                                string door_478 = "- Так вы же меня не спрашивали.";
                                string door_479 = "- И то верно…";
                                string door_480 = "<i>Возвращаясь домой, я не мог не думать обо всем этом.\n\n По пути я забрел в какой-то двор с качелями. Там не было ни детей, ни взрослых, ни даже птиц. Идеальное место для размышлений.\n\nМеня словно током пронзило. Ведь именно этот двор я видел в своих воспоминаниях.\n\nКакое-то время я сидел на качели, но затем решил побродить по нему.\n\nЯ не знал, что ищу и ищу ли вовсе. Вполне вероятно, что, раз это другая реальность, то я не найду здесь ничего важного.\n\nОбойдя двор вдоль и поперек, я пришел к выводу, что, возможно, так оно и есть, как вдруг что-то блеснуло в траве…\n\nЯ подошел ближе и наклонился. Это оказалась заколка.\n\nНа вид ничего необычного, но я чувствовал, что это не так.\n\nВзяв ее в руку, я ощутил, как меня что-то кольнуло. Я снова что-то видел…\n\nДевушка, сидящая у зеркала. Она расчесывает свои длинные, черные, как смоль, волосы. Я подаю ей заколку… На этом видение кончается.\n\nЯ так и  не увидел ее лица.Кто она?\n\nКто все эти девушки, которые являются мне в воспоминаниях?\n\nЯ чувствую, что забыл что-то очень важное, намного важнее всего прочего.\n\nМне необходимо это вспомнить.</i>";
                                string door_481 = "<i>Я провел в том дворе несколько часов.\n\nНа улице уже успело стемнеть. Вдоль дорог зажглись первые фонари, а на безоблачном небе стали проглядываться звезды. Яркие и недостижимые, они манили меня. Казалось, в них было сокрыто нечто большее, чем просто красота…\n\nЯ вновь видел ту девушку. Мы лежали на крыше, взявшись за руки, разговаривали о звездах…\n\n«Миш… Ты знал?»\n\n«Что?»\n\n«Говорят, звезды – это человеческие сердца. И, чем сильнее сердце, чем сильнее его мечты и чувства, переполняющие его, тем ярче горит его звезда…»\n\n«Но ведь, сгорая, звезды падают на Землю и разбиваются?»\n\n«Да… Это плата… Плата за их свет… За все приходится платить…»\n\nПосле этих странных слов видение рассеялось. Я вновь был один в пустом дворе.\n\nНужно было возвращаться домой. Алена наверняка волнуется…</i>";
                                string door_482 = "<i>Я поднялся на шестнадцатый этаж своего подъезда, подошел к двери и постучал. Мне никто не ответил. Потом я постучал еще и еще.\n\nВыхода не было.\n\nНащупав кармане джинс ключи, я отпер ее и заглянул внутрь.\n\nНичего особенного или подозрительного не наблюдалось. Однако все – выключенный свет, тишина, указывало на то, что в квартире никого нет.\n\nЯ обошел все комнаты и не нашел никаких признаков пребывания здесь сестры или кого-то еще. Ни вещей, ни фотографий. Абсолютная пустота. Я был совершенно один…</i>";
                                string door_483 = "<i>Возможно в этом мире у меня никогда и не было сестры. Я не могу этого знать. Миры за каждой из тех дверей отличаются друг от друга, так что, вполне вероятно, что я могу быть единственным ребенком или сиротой…\n\nТак иначе, я не мог больше думать об этом. Какой бы соблазнительной ни была тайна, некоторые вопросы лучше навсегда оставить без ответа…</i>";
                                string door_484 = "<i>На следующий день я вновь отправился на учебу.\n\nЯ больше не спал на лекциях  и не ссорился с преподавателями. И, казалось бы, все было отлично, но только у меня.\n\nВитя выглядел обеспокоенным, поэтому я спросил его о том, что произошло.</i>";
                                string door_485 = "- Жанна…";
                                string door_486 = "- Что с ней?";
                                string door_487 = "- Она вчера поругалась с отцом и сбежала ночью. Я не знаю точно куда. Я уже все обыскал, не могу до нее дозвониться. Места себе не нахожу…";
                                string door_488 = "- Так. Соберись. Мы ее найдем. Ты уверен, что не знаешь, куда она могла пойти?";
                                string door_489 = "<i>Он покачал головой и закусил губу.</i>";
                                string door_490 = "- Боюсь, с ней могло произойти что-то нехорошее… Ты ведь знаешь, какая она… ";
                                string door_491 = "- Я помогу тебе ее найти. Вот увидишь. Все будет хорошо.";
                                string door_492 = "<i>Друг лишь грустно посмотрел на меня.</i>";
                                string door_493 = "- Спасибо. Надеюсь, что ты прав…";
                                string door_494 = "<i>Я не знал, куда иду. Ноги сами вели меня вперед, иногда сворачивая, но маршрут будто бы был мне знаком. Все эти дома, тропинки и деревья. Все это я уже видел когда-то давно, просто не мог вспомнить.\n\nВ конце концов я действительно нашел ее.\n\nЯ увидел Жанну издалека. Она сидела на скамейке и плакала. Я хотел было подойти, но остановился, увидев, как группа гопников приблизилась к ней.\n\nЭто выглядело опасно.</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_40, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_41, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_42, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_43, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_44, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_45, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_46, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_47, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_48, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_49, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_410, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_411, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_412, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_413, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_414, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_415, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_416, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_417, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_418, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_419, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_420, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_421, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_422, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_423, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_424, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_425, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_426, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_427, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_428, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_429, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_430, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_431, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_432, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_433, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_434, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_435, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_436, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_437, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_438, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_439, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_440, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_441, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_442, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_443, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_444, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_445, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_446, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_447, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_448, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_449, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_450, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_451, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_452, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_453, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_454, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_455, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_456, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_457, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_458, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_459, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_460, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_461, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_462, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_463, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_464, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_465, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_466, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_467, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_468, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_469, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_470, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_471, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_472, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_473, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_474, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_475, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_476, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_477, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_478, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_479, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_480, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_481, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_482, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_483, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_484, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_485, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_486, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_487, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_488, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_489, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_490, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_491, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_492, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_493, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Вмешаться."),

                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Уйти."),
                                                },

                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                string[] keys = { "Войти в четвертую дверь", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_494, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);

                            }
                            else if (message.Text == "Вмешаться.")
                            {
                                string door_495 = "<i>Я не мог просто оставить ее. Я знал, что с таким характером, как у нее, ничего хорошего не жди, особенно, когда связываешься с такой компанией.</i>";
                                string door_496 = "<i>Собрав всю смелость в кулак, я направился вперед.</i>";
                                string door_497 = "- Ого! Что это у нас за горячая штучка на районе? Почему я тебя раньше не видел?";
                                string door_498 = "<i>Жанна скривилась от отвращения.\n\nВсе выглядело еще опаснее, чем могло быть, поэтому я ускорил шаг.</i>";
                                string door_499 = "- Потому, что я не общаюсь с такими жалкими, недоразвитыми, гнилыми отбросами общества, как ты!";
                                string door_4100 = "<i>К тому моменту, когда все грозилось перерасти в серьезную проблему, я оказался в шаге от нее.</i>";
                                string door_4101 = "- Нарываешься? Знаешь… А мне нравятся такие сучки, как ты… Пора бы кому-нибудь поучить тебя манерам.";
                                string door_4102 = "- Ну уж точно не тебе!";
                                string door_4103 = "- Миша?..";
                                string door_4104 = "<i>Жанна удивленно посмотрела на меня. Она выглядела испуганной.\n\nГлаварь банды недовольно на меня посмотрел.\n\nГде-то я уже видел это лицо…\n\nИ я не ошибся. Это он был в баре.</i>";
                                string door_4105 = "- А ты еще кто такой? Парень этой девки?!";
                                string door_4106 = "<i>Как я и думал, он не мог меня помнить.</i>";
                                string door_4107 = "- Это тебя не касается. Оставьте ее в покое.";
                                string door_4108 = "- А не то что? Побьешь меня?";
                                string door_4109 = "- Если не уйдете по-хорошему – придется.";
                                string door_4110 = "- Ну что ж… Если ты так настаиваешь на драке…";
                                string door_4111 = "<i>Громила нанес первый удар. Жанна испуганно вскрикнула, но я выстоял.\n\nЧестно говоря, не знаю, как у меня вышло, я и не рассчитывал на победу. Тело двигалось само. В итоге они все сбежали.\n\nОтряхнувшись, я подошел к ней. Она все еще сидела на скамейке, словно боясь пошевелиться.</i>";
                                string door_4112 = "- Ты как?";
                                string door_4113 = "- Как я? Ты спрашиваешь, как я?";
                                string door_4114 = "- Ну да…";
                                string door_4115 = "<i>Меня немного ошарашил этот вопрос.</i>";
                                string door_4116 = "- Ты только что полез в одиночку драться с целой кучей головорезов и спрашиваешь, как я?";
                                string door_4117 = "- Ну да…";
                                string door_4118 = "- Они могли тебя убить!";
                                string door_4119 = "- А тебя изнасиловать. Сама то хоть понимаешь, что виновата?";
                                string door_4120 = "- Я…";
                                string door_4121 = "<i>Она опустила голову.</i>";
                                string door_4122 = "- Ладно, забудь. Твой брат с ума сходит. Так сильно волнуется. Совсем тебя обыскался. Перезвони ему…";
                                string door_4123 = "<i>Я собирался отвести ее к Вите.</i>";
                                string door_4124 = "- Постой…";
                                string door_4125 = "<i>Она развернула меня к себе и, прежде, чем я успел что-либо осознать, поцеловала, затем оттолкнув.</i>";
                                string door_4126 = "- Спасибо тебе…";
                                string door_4127 = "<i>*Постельная сцена*</i>";
                                string door_4128 = "<i>Я вновь провалился во тьму…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_495, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_496, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_497, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_498, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_499, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4100, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4101, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4102, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4103, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4104, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4105, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4106, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4107, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4108, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4109, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4110, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4111, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4112, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4113, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4114, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4115, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4116, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4117, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4118, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4119, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4120, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4121, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4122, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4123, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4124, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4125, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4126, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4127, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4128, false, false, 0, keyboardDoor5, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Вмешаться.", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            else if (message.Text == "Уйти.")
                            {
                                string door_4129 = "<i>Я решил, что оно не стоит того. Я вызвал копов, позвонил Вите и сказал, что кто-то из прохожих видел ее там, а затем ушел.\n\nЖанну изнасиловали. Следующим вечером в больнице она покончила с собой, а я вернулся в ту самую комнату с шестью дверями…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_4129, false, false, 0, keyboardDoor5, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Уйти", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            //дверь №5
                            else if (message.Text == "Войти в пятую дверь")
                            {
                                string door_50 = "<i>Открывая дверь с человеческой рукой вместо ручки, я, вероятно, должен был подумать о странностях, которые будут происходить далее, но я и подумать не мог, что окажусь на месте убийства…\n\nДень мой начался весьма и весьма обычно. Я встал и заварил кофе, принял душ. Позже даже решил выйти на пробежку. Почти как самый обычный человек.\n\nПарк, который я выбрал, был пуст. Это и не удивительно. В такую рань редко кого встретишь на улице.\n\nЯ слышал шелест листвы, чувствовал на себе порывы теплого летнего ветра.\n\nПо надвигающимся с востока тучам я предположил, что ближе ко второй половине дня будет дождь.\n\nДождь… Я был под ним и ранее, там, с Ириной, но тогда совсем не задумывался о нем.\n\nТогда я не ждал его приближения.\n\nЯ вообще ничего не ждал.\n\nТеперь ожидание казалось чем-то важным, чем-то особенным.\n\nМою голову вновь начали наполнять воспоминания. Картинки, звуки, чувства – их было так много, что меня разрывало изнутри.</i>";
                                string door_51 = "<i>Я сидел у камина и читал.  Было тихо и спокойно, но я не был один. Со мной была девушка. Девушка с красными волосами.\n\nОна подошла к окну и распахнула его, впустив в комнату порыв теплого ветра и указала на небо.\n\n«Совсем скоро будет дождь…»</i>";
                                string door_52 = "<i>Видение застало меня врасплох. Я и не помнил, что нахожусь в парке.\n\nЭтот голос… Я уже слышал его…\n\nСлышал в ином воспоминании…\n\nЗвук грома протрезвил меня.\n\nЯ оглянулся. В парке по-прежнему было тихо.\n\nНикого, ни единой души вокруг… Так это было… Или нет?\n\nКажется у меня развилась мания преследования.\n\nЯ чувствовал на себе чей-то взгляд. Взгляд, который пронзал меня насквозь, но я не мог сказать, кому он принадлежит.\n\nГром лишь усиливал мою тревогу.\n\nТела коснулись первые капли дождя. Они были удивительно холодные. Ветер усиливался. Тучи надвигались все стремительнее.\n\nЯ побежал…\n\nДождь скоро перерос в ливень.\n\nЯ чувствовал, как мокрая насквозь одежда липнет к телу, слышал чавканье в кроссовках – в них, верно, уже затекла вода. Волосы тоже намокли.\n\nЯ бежал, ускоряясь, но стихия была быстрее и сильнее меня. От нее было не скрыться. От нее и этого проклятого взгляда.\n\nЯ бежал, не обращая внимания на холод и на то, как болезненно сжимаются легкие.\n\nВ конце концов даже дышать стало не выносимо, но я не мог остановиться. Что-то внутри говорило мне не останавливаться. Я должен был где-нибудь укрыться. Где-нибудь, где этот взгляд не сможет меня достигнуть.\n\nЯ бежал домой…\n\nНо можно ли это назвать домом?..\n\nЯ схватился за голову.\n\nЧто-то мелькнуло в моей голове. Короткое, болезненное воспоминание.\n\nДело было не в грусти. Я чувствовал боль.</i>";
                                string door_53 = "<i>«Миша, ужин готов…»</i>";
                                string door_54 = "<i>Эти три слова эхом раздавались в стенках моего черепа.\n\nБоль была невыносимой.\n\nВсе, происходящее вокруг, казалось мне страшным сном.\n\nТак не должно быть…\n\nСлишком тихо... Пугающе тихо…\n\n На улицах царило полное безмолвие…\n\nЯ не видел машин, не видел людей…\n\nБудто с лица земли стерли все живое... Все, кроме меня и того чудовищного взгляда, который заставлял меня бежать…</i>";
                                string door_55 = "<i>Добравшись до дома, я наглухо запер за собой дверь, но и это меня не успокоило.\n\nСердце колотилось, как при тахикардии…\n\nЯ слышал, как оно бьется в груди. Даже шум дождя не в силах его заглушить…\n\nДождь… Почему я его все еще слышу?\n\nЯ зажал уши руками, но это не помогло. Я слышал голос. Голос в своей голове…</i>";
                                string door_56 = "<i>«Миш, я не могу уснуть… Этот дождь… Мне тревожно… Поспишь со мной?..»</i>";
                                string door_57 = "<i>Не знаю, когда я опомнился, но я знал, что делать…\n\nЯ пошел в комнату с открытым окном и закрыл его. Шум тут же стих.\n\nЯ задумался.\n\nЯ ведь совсем не помнил, чтобы открывал его…\n\nМеня кольнуло страшное подозрение. Вскочив на ноги, я схватил кухонный нож и, сглотнув, начал не спеша обходить комнаты – одну за другой…\n\nЯ ничего не нашел.\n\nСил не оставалось ни на что. Кое-как шевелясь, я переоделся и упал на кровать. Но ни усталость, ни холод не заставили меня уснуть…\n\nТревога не прошла. Напротив, она только усиливалась в каждым ударом моего сердца.\n\nЯ больше не мог оставаться один.\n\nНо куда мне идти? К кому?\n\nЯ ничего не знал об этом мире.\n\nЕсть ли место, куда я могу пойти?\n\nЯ не знал ответа ни на этот, ни на другие важные вопросы.\n\nЭто убивало меня.\n\nАлена, Витя, Дима, Ира, Аня и даже Жанна – есть ли они где-то здесь?\n\nЯ не мог поверить в то, что здесь нет ни одного из них.\n\nЯ не знал, где их искать, но и не мог здесь оставаться…</i>";
                                string door_58 = "<i>Когда я вышел из дома, ливень уже перерос в шторм.\n\nЯ промок до нитки, едва добравшись до машины.\n\nЯ практически ничего не видел за стеклом. Даже дворники практически не спасали.\n\nЕхать в такую погоду было опасно, но необходимо.\n\nЯ знал, что не смогу успокоиться, пока не найду их. Хоть кого-нибудь...</i>";
                                string door_59 = "<i>Дома оказались пусты.\n\nДаже в колледже и пабе не было ни единой живой души.\n\nЯ зашел в несколько магазинов, но не заметил ни продавцов, ни охраны, ни тем более покупателей…\n\nКак будто  апокалипсис наступил. Все исчезли…\n\nЯ не хотел возвращаться домой…</i>";
                                string door_510 = "<i>Не найдя лучшей альтернативы, я решил вернуться в паб. Там мне было спокойнее всего…\n\nЯ занял место в углу и начал вспоминать тот день с Аней, а потом и тех, других людей, что я встречал…\n\nСейчас я бы все отдал за то, чтобы поговорить хоть с кем-нибудь. Тишина сводила меня с ума…\n\nСложив руки на столе, я устало положил на них голову.\n\nУ меня совсем не осталось сил…</i>";
                                string door_511 = "<i>Мне снилось, что я лежу у кого-то на коленях. Чьи-то руки нежно гладят меня по голове.\n\nЭто была девушка. Она пела.\n\nЯ уже слышал эту мелодию…</i>";
                                string door_512 = "<i>Меня разбудил стук кружки, когда кто-то поставил ее прямо передо мной на стол.\n\nЯ поднял голову.\n\nОн был наполнен алкоголем. Кажется темным пивом.</i>";
                                string door_513 = "- Кто здесь? ";
                                string door_514 = "<i>Я начал оглядываться по сторонам, пытаясь что-то разглядеть, но барная стойка была покрыта мраком.</i>";
                                string door_515 = "- А я думал ты узнаешь старого друга…";
                                string door_516 = "<i>Фигура не спеша вышла из тени на свет. Я слышал стук шагов, а затем увидел лицо…</i>";
                                string door_517 = "- Дима?!";
                                string door_518 = "<i>Неожиданное появление парня меня удивило.</i>";
                                string door_519 = "- Он самый.";
                                string door_520 = "<i>Он слегка улыбнулся уголками губ.</i>";
                                string door_521 = "- Пей, это тебя согреет. ";
                                string door_522 = "<i>У него в руках оказалась такая же кружка.\n\nЯ какое-то время мешкался, но Дима начал пить и я тоже решился.\n\nВпервые за все время, что я провел в этой реальности, рядом оказался кто-то, кого я знаю.\n\nНа душе стало спокойнее.</i>";
                                string door_523 = "- Приятно видеть знакомое лицо на живом человеке.";
                                string door_524 = "- И то верно…";
                                string door_525 = "<i>Я улыбнулся в ответ.</i>";
                                string door_526 = "- Но… Что ты здесь делаешь? Я думал здесь никого нет…";
                                string door_527 = "<i>Я не мог не задать ему интересующий меня вопрос.</i>";
                                string door_528 = "- Так и есть…";
                                string door_529 = "<i>Ответ прозвучал задумчиво. Дмитрий почти не смотрел на меня.</i>";
                                string door_530 = "- Но почему?! Куда все пропали?!";
                                string door_531 = "<i>Дима прислонил палец к губам.</i>";
                                string door_532 = "- Ты ведь не хочешь, чтобы нас услышали?";
                                string door_533 = "- Ничего не понимаю… - <i>сказал я уже тише.</i>";
                                string door_534 = "- Почему мы говорим шепотом?";
                                string door_535 = "- Здесь больше нигде не безопасно…";
                                string door_536 = "- Ты о погоде? Из-за нее нигде никого нет?";
                                string door_537 = "- Погода…";
                                string door_538 = "- Да, на улице настоящий шторм. Я едва добрался сюда.";
                                string door_539 = "- Нет… погода здесь не при чем…";
                                string door_540 = "- А что тогда?";
                                string door_541 = "- Даже мир отторгает ее…";
                                string door_542 = "- Кого?";
                                string door_543 = "- Она несет лишь гибель…";
                                string door_544 = "- Кто она? Да ответь ты уже наконец!";
                                string door_545 = "<i>Его уход от ответа меня пугал и злил, но я ничего не мог поделать.</i>";
                                string door_546 = "- Думаю, ты лучше меня знаешь ответ на этот вопрос…";
                                string door_547 = "<i>Мелодия из воспоминания, тот голос – все это вновь звучало в моей голове. Громче, чем можно себе представить.</i>";
                                string door_548 = "<i>Я закричал от боли, не в силах расслышать собственного голоса, но пытка на этом не закончилась.\n\nЯ видел девушку… Сперва с голубыми волосами, затем – с зелеными, белыми, черными и, наконец, красными, но ни в одной не мог признать никого из тех девушек, которых встречал раньше.</i>";
                                string door_549 = "- Почему я его слышу? Почему вижу все это? Что я должен делать?";
                                string door_550 = "<i>Я был напуган. Я действительно ничего не понимал.</i>";
                                string door_551 = "- Она злится… Злится, что ты забыл ее…";
                                string door_552 = "<i>Мелодия продолжала звучать в моей голове, будто кто-то специально внушал ее мне неведомым способом.</i>";
                                string door_553 = "- Кто? Да кто же?!";
                                string door_554 = "<i>Он промолчал.</i>";
                                string door_555 = "- Я не могу ответить тебе на этот вопрос…";
                                string door_556 = "- Ты шутишь?!";
                                string door_557 = "<i>Я был готов убить его и, наверное, так бы и поступил, если бы не знал, что это не покончит с моими мучениями.</i>";
                                string door_558 = "- Почему здесь только ты?";
                                string door_559 = "<i>Я истерически рассмеялся.</i>";
                                string door_560 = "- Разве не очевидно?";
                                string door_561 = "<i>Дима не спешил закончить фразу, но, осознав, что я не знаю ответа, продолжил.</i>";
                                string door_562 = "- Потому, что она не может меня найти…";
                                string door_563 = "- Почему?";
                                string door_564 = "<i>Дима начал медленно уходить в тень.</i>";
                                string door_565 = "- Потому, что я хорошо прячусь…";
                                string door_566 = "- Подожди!";
                                string door_567 = "<i>Я встал и побежал в ту сторону, куда он уходил, но меня словно замедлили. Я никак не мог за ним поспеть…</i>";
                                string door_568 = "- Не уходи! У меня еще так много вопросов!";
                                string door_569 = "- Как и у всех…";
                                string door_570 = "- Откуда ты все это знаешь?!";
                                string door_571 = "- Желание узнать все вещи и постигнуть их истину, заложено в нас от природы…";
                                string door_572 = "- Это Альбрехт Дюрер?";
                                string door_573 = "- Верно.";
                                string door_574 = "<i>В его голосе послышались одобрительные нотки.</i>";
                                string door_575 = "- Не скажешь, почему помнишь его?";
                                string door_576 = "- Я…";
                                string door_577 = "<i>Я не знал, что ответить.</i>";
                                string door_578 = "<i>«Юи, ты слишком любопытная, даже для девушки!» - весело подметил я.\n\nОна хихикнула.\n\n«Желание узнать все вещи и постигнуть их истину, заложено в нас от природы».\n\n«Кто это сказал?»\n\n«Альбрехт Дюрер».\n\n«Кто он?»\n\n«Знаменитый немецкий художник! Его работы гениальны!»</i>";
                                string door_579 = "<i>Воспоминание вырвало меня из реальности. Когда я опомнился, Дима уже исчез во тьме за барной стойкой.\n\nЯ позвал его, но мне никто не ответил.\n\nМне не оставалось ничего, кроме как последовать за ним во мрак…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_50, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_51, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_52, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_53, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_54, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_55, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_56, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_57, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_58, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_59, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_510, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_511, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_512, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_513, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_514, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_515, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_516, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_517, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_518, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_519, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_520, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_521, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_522, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_523, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_524, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_525, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_526, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_527, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_528, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_529, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_530, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_531, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_532, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_533, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_534, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_535, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_536, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_537, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_538, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_539, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_540, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_541, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_542, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_543, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_544, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_545, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_546, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_547, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_548, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_549, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_550, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_551, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_552, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_553, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_554, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_555, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_556, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_557, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_558, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_559, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_560, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_561, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_562, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_563, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_564, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_565, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_566, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_567, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_568, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_569, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_570, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_571, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_572, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_573, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_574, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_575, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_576, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_577, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_578, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_579, false, false, 0, keyboardDoor6, ParseMode.Html); Thread.Sleep(4000);
                                string[] keys = { "Войти в пятую дверь", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                            }
                            else if (message.Text == "Войти в шестую дверь")
                            {
                                string door_60 = "<i>Тьма привела меня к шестой двери…\n\nЯ огляделся...\n\nДмитрия нигде не было…\n\nЯ побывал за каждой из дверей, кроме этой…\n\nОна была покрыта чем-то бардовым – в тусклом освещении было не различить…\n\nТо ли ржавчина, то ли истлевшая краска покрывала ее сверху донизу…\n\nНо меня кольнуло другое, страшное подозрение…\n\nМне казалось, это человеческая кровь, вот только чья?..\n\nМне было страшно. Впервые за долгое время я был готов остаться в этой комнате с дверями, лишь бы не идти дальше. Все мое естество было против этого, но я не мог…\n\nЭта история будет продолжаться до тех пор, пока я все не вспомню…\n\nПереступив через страх и чувство тревоги, я потянул за ручку.\n\nДверь едва поддалась. Чтобы открыть ее, мне пришлось тянуть изо всех сил. Я услышал жуткий скрип и скрежет. Наверное такой звук издает дверь, которую давным-давно никто не отпирал…\n\nНо она не была такой, когда я впервые очнулся в той комнате…</i>";
                                string door_61 = "<i>Не без опасения я огляделся, но ничто вокруг меня не вызывало тревоги.\n\nБыл обычный солнечный день. Солнце не пекло, но приятно грело. В такие редкие дни люди выбираются из своих домов, чтобы встретиться с близкими, погулять, поболтать или просто хорошо провести время.\n\nЯ оказался в парке, но он был другим…\n\nЯ сидел на лавочке возле фонтана. Сквозь тонкие струйки и капли воды проглядывались едва заметные радуги. Я был окружен людьми и цветами, но что-то не давало мне покоя.\n\nКто-то подошел и заговорил со мной, но я не слышал слов…\n\nВсе выглядели такими добрыми и счастливыми, но я никак не мог перестать думать о том, что за всем этим скрывается фальшь…\n\nЯ не знал этих людей. В моем мире их не существовало. Не существовало и их альтернативных личностей…\n\nЯ словно оказался в идеально мире. Утопической реальности, где повсюду царил покой, где не случается ничего плохого. В этом мире меня окружали живые манекены…\n\nМеня окружали толпы безликих манекенов.Бесчувственных кукол, собранных для величайшего представления этого века. Представления, имя которому – жизнь…\n\nЯ бродил среди улиц и ничего не узнавал. Все, что было мне так знакомо, словно стерли, исказили, исковеркали, очернили…\n\nВся эта показная утопия вызывала во мне неистовое отвращение…\n\nЯ ничего не мог поделать…\n\nКто-то в толпе случайно коснулся меня.\n\nЯ сразу же отдернул руку…</i>";
                                string door_62 = "- Ты тоже чувствуешь?";
                                string door_63 = "<i>Я обернулся.\n\nЖивой, человеческий голос, совсем не вязался со всем, что меня окружало.\n\nЭто был Дима…</i>";
                                string door_64 = "- Чувствую что?";
                                string door_65 = "- Они все фальшивки…";
                                string door_66 = "<i>Ему не требовалось показывать пальцем, чтобы я понял, о чем он говорит.</i>";
                                string door_67 = "- Да… Я сразу заметил… Что это за место? Почему здесь так?";
                                string door_68 = "- Этот мир…так же пуст, как предыдущий. Возможно даже хуже его…";
                                string door_69 = "- О чем ты говоришь?..";
                                string door_610 = "- Скоро ты сам все поймешь… В этом мире нужно быть начеку…";
                                string door_611 = "- Ты снова собираешься уйти?";
                                string door_612 = "<i>Он улыбнулся.</i>";
                                string door_613 = "- Это больше не прятки. Это охота… Я в ней – лишь часть желаемой добычи…";
                                string door_614 = "- Но… Что ей нужно?..";
                                string door_615 = "- Я думал, ты уже знаешь ответ…";
                                string door_616 = "<i>Я…</i>";
                                string door_617 = "- Но почему? Что ей от меня нужно? Почему я все забыл?..";
                                string door_618 = "- Этот спектакль для тебя… Наслаждайся…";
                                string door_619 = "<i>Дмитрий в мгновение ока скрылся в толпе.\n\nЯ последовал за ним, но, как ни старался, не мог его разглядеть…</i>";
                                string door_620 = "<i>Стоило отдать ему должное. Прятаться он действительно умел. Ища такого человека можно запросто потеряться самому. Это и случилось со мной…\n\nНе успел я опомниться, как оказался в неизвестном месте, которое я никак не мог связать с теми, что посещал ранее. Оно было похоже на пустырь…\n\nТакое жуткое, чужое этому миру место. Ему не было места в этой реальности…\n\nИ все же, все здесь казалось таким неправильным… Значит ли это, что единственно правильным является этот пустырь?..\n\nЯ задумался о том, может ли одно исключать второе и не заметил, как начал узнавать в этом месте двор…\n\nТот самый двор, в котором я нашел заколку…\n\nВ одном мире он был полон детей, в другом – пуст, в этом же он являл собой пустырь…\n\nЯ будто плыл сквозь время…\n\nВремя…\n\nМожет это и правда так… Я ведь никогда не задумывался, есть ли разница во времени между этими мирами…\n\nЯ облокотился о ствол дерева. Ветер приятно шевелил волосы на моей голове.\n\nЭто напомнило мне о чем-то. О чем-то важном…</i>";
                                string door_621 = "<i>Я лежал где-то в поле на траве. Я чувствовал, как ветер щекочет мое тело травинками. Со мной была девушка с каштановыми волосами. Она лежала на моем плече. Меня переполняло чувство полного внутреннего умиротворения…</i>";
                                string door_622 = "«Миш…»";
                                string door_623 = "«Да?»";
                                string door_624 = "«Спасибо тебе за сегодня… Я так рада, что мы провели этот день вместе…»";
                                string door_625 = "«Разве я мог иначе? Я ведь люблю тебя».";
                                string door_626 = "«Сказал!»";
                                string door_627 = "«Что?»";
                                string door_628 = "«Ты в самом деле это сказал!»";
                                string door_629 = "«Ну да».";
                                string door_630 = "«Ты сказал это впервые. Я так рада!»";
                                string door_631 = "<i>Она кинулась мне на шею…</i>";
                                string door_632 = "«Эй, погоди, задушишь ведь…»";
                                string door_633 = "<i>Я схватился за голову. В последнее время боль от видений стала невыносимой…\n\nЧто-то случилось после этого… Я чувствовал... Это было одно их последних воспоминаний…\n\nЧто-то важное… Что-то, что я не должен был забывать… Что-то настолько ужасное, что мой разум противится этим воспоминаниям…</i>";
                                string door_634 = "«Скоро стемнеет. Время ехать домой…»";
                                string door_635 = "«Что-о? Как? Уже?!»";
                                string door_636 = "<i>Девушка обижено надула губки.</i>";
                                string door_637 = "«Прости уж. Мы еще вернемся сюда…»";
                                string door_638 = "«Обещаешь?»";
                                string door_639 = "«Обещаю…»";
                                string door_640 = "<i>Боль, пульсировавшая в висках, усиливалась с каждой секундой…\n\nКазалось, я не выдержу этого, но я должен был вспомнить…</i>";
                                string door_641 = "<i>Мы ехали на мотоцикле по ночному городу. Уже успело стемнеть. Повсюду начали загораться огни…\n\nМы завернули за угол, чтобы сократить путь… Там не горел фонарь…\n\nПотом… Что-то случилось…\n\nУ меня отказали тормоза… Я ничего не видел…\n\nВ тот день я не надел шлем…\n\nСмешно и глупо…\n\nПогиб из собственного упрямства…\n\nМысли медленно меркли в моем сознании… Дело было не в боли… Само мое сознание перестало существовать…\n\nТогда я услышал последние слова Юи… Теперь я уверен, что ее звали так… </i>";
                                string door_642 = "«…Я найду тебя в других мирах…»";
                                string door_643 = "<i>Я закричал…</i>";
                                string door_644 = "- Смотрю, ты все вспомнил… Все верно. Ты мертв.";
                                string door_645 = "<i>Это был голос Дмитрия.</i>";
                                string door_646 = "- Но как?! Я ведь стою здесь, слышу и вижу тебя, мы разговариваем, я могу мыслить!";
                                string door_647 = "- Мыслю – значит существую? ";
                                string door_648 = "- Да!";
                                string door_649 = "- Увы, но твое существование в этом мире не исключает смерти в другом…";
                                string door_650 = "- Но как такое возможно?!";
                                string door_651 = "- Юи заплатила немалую цену… Теперь у тебя, как и у нее, есть способность перемещаться между  паралельными реальностями… Когда ты погиб – она пришла ко мне…";
                                string door_652 = "- Но зачем?";
                                string door_653 = "- Она слишком любила тебя, чтобы отпустить… Юи искала способ встретиться с тобой снова. С настоящим тобой. Тем кого она знала…";
                                string door_654 = "- И ты рассказал ей? ";
                                string door_655 = "- Да.";
                                string door_656 = "- Как?";
                                string door_657 = "- Для этого пришлось собрать все твои альтернативные личности… Конечно она пренебрегла моим предупреждением…";
                                string door_658 = "- Каким предупреждением?";
                                string door_659 = "- Когда грань между мирами нарушается и человек вбирает в себя все черты своих альтернативных оболочек, он теряет себя. Он больше не знает, какой из них настоящий. В нем множество людей. Это сводит с ума… Причиняет боль, не только моральную, но и физическую… Такого никто не выдержит… Даже один переход – это огромный риск… Представляешь, чем грозит шесть переходов или больше?..";
                                string door_660 = "- Что ты имеешь в виду?";
                                string door_661 = "- Она больше не та Юи, которую ты знал…";
                                string door_662 = "- В смысле?";
                                string door_663 = "- Она потеряла себя, пока пыталась найти тебя… Поэтому я и скрываюсь…";
                                string door_664 = "- Но как же я? Я ведь тоже перемещаюсь! Да и ты тоже!";
                                string door_665 = "- Ты умер. Считай, что родился заново. Это другое. А я и не говорил, что я в своем уме.";
                                string door_666 = "- Значит Юи сходит с ума?";
                                string door_667 = "- Верно… Даже тебе приходится нелегко, не смотря на то, что ты все забыл…";
                                string door_668 = "- Она хочет убить тебя?";
                                string door_669 = "<i>Дмитрий рассмеялся.</i>";
                                string door_670 = "- О да, думаю так и есть… Впрочем, ты и сам скоро встретишься с ней… ";
                                string door_671 = "- Но… Я не готов! Я не знаю, что делать!";
                                string door_672 = "- Ты сам все поймешь, когда придет время…";
                                string door_673 = "- А ты? Ты снова уходишь?";
                                string door_674 = "- Она уже давно ищет тебя. Скоро ей это удастся. Мне лучше быть как можно дальше от тебя, когда это произойдет…";
                                string door_675 = "- Она ведь не убьет меня, правда?..";
                                string door_676 = "- Все зависит от тебя… Но на твоем месте я бы позаботился о том, как ты будешь защищаться… Прощай… Мы еще встретимся…";
                                string door_677 = "<i>Дмитрий исчез, а я так и остался стоять.\n\nОн был прав.\n\nЕсли Юи, кем бы она сейчас ни была, способна на такое, значит придется самому защитить себя…\n\nЯ направился домой, схватил кухонный нож и заперся в своей комнате, ожидая своего часа…\n\nОна ведь может и не признать меня… Дмитрий говорил, она зла из-за того, что я забыл ее…\n\nРаздался звонок…\n\nЯ с ужасом посмотрел на экран телефона, на котором высветился неопознанный номер. Сердце колотилось до боли в груди. Меня охватил панический приступ тошноты…\n\nЯ не мог заставить себя ответить на звонок, но он звучал все настойчивее, не оставляя мне выбора…\n\nЯ принял вызов…</i>";
                                string door_678 = "«Миш…»";
                                string door_679 = "<i>Без сомнения это был голос Юи… Шепот, произносимый ее губами, пронзал меня насквозь, заставляя дрожать от смешанного чувства.\n\nЯ сглотнул. Нужно было что-то ответить, но я не мог выдавить из себя ни звука…</i>";
                                string door_680 = "«Я знаю, ты слышишь меня…»";
                                string door_681 = "<i>Я зажал рот рукой. Казалось, она слышит все…</i>";
                                string door_682 = "«Нам нужно встретиться… Приходи на пустырь… Ты знаешь, где это… Прошу тебя, не оставляй меня одну… Ты очень нужен мне… Ты – моя последняя надежда…»";
                                string door_683 = "<i>Ее голос был полон горя и тоски…</i>";
                                string door_684 = "<i>Она бросила трубку…\n\nЯ знал, что нельзя к ней приближаться. Чувствовал это. Но что-то заставляло меня идти…\n\nЯ спрятал нож в карман и отправился в путь…</i>";
                                string door_685 = "<i>В течении всего пути меня преследовал страх…\n\nПришло время встретиться с ним лицом к лицу… Жди меня, Юи…</i>";
                                string door_686 = "<i>Она стояла там же, под деревом, где некогда стоял я… Она была в маске…</i>";
                                string door_687 = "- И все-таки ты пришел…";
                                string door_688 = "- Ты ведь все равно нашла бы меня…";
                                string door_689 = "- И то верно…";
                                string door_690 = "<i>Юи вышла из тени, приблизившись ко мне. Я отступил…</i>";
                                string door_691 = "- Прости… Я не хотела пугать тебя… Мы ведь впервые вот так разговариваем…";
                                string door_692 = "- Ты ведь наблюдала за мной и раньше, верно? В тех, других мирах…";
                                string door_693 = "- Ты прав. Конечно приходилось скрываться. Ты… Был не готов видеть меня…";
                                string door_694 = "- Почему ты пошла на такой риск ради меня?";
                                string door_695 = "- Разве не очевидно? Я все еще люблю тебя…";
                                string door_696 = "- Этот мир… Почему ты решила встретиться со мной именно здесь?";
                                string door_697 = "- Ты начал вспоминать прошлое. Наше прошлое… А Дмитрий не промах… Уже сделал первый ход…";
                                string door_698 = "- Он ушел.";
                                string door_699 = "- Да… Знаю…";
                                string door_6710 = "- Ты убьешь меня?";
                                string door_6711 = "- Это тебе он сказал?";
                                string door_6712 = "<i>Я не ответил, внимательно наблюдая за каждым ее движением. Но до сих пор от Юи не исходила угроза…</i>";
                                string door_6713 = "- Забудь… Мы с ним не очень-то ладим… Наконец-то я могу разговаривать с тобой… Я так долго этого ждала… Я ведь обещала тебе, помнишь? Обещала, что найду тебя…";
                                string door_6714 = "- Да… Я все вспомнил…";
                                string door_6715 = "- Теперь, после всего, ты боишься меня?..";
                                string door_6716 = "<i>В голосе послышалась нескрываемая грусть…</i>";
                                string door_6717 = "- Я…";
                                string door_6718 = "<i>Я не мог признаться ей в этом, как и себе. Сейчас, находясь напротив нее, я не мог сказать, что боюсь ее. Я не верил, что она способна причинить мне вред…</i>";
                                string door_6719 = "- Я не боюсь тебя, Юи…";
                                string door_6810 = "- Тогда… Можешь побыть сегодня со мной?.. С того дня… Прошло так много времени… Я не перестаю винить себя за ту аварию… Если бы я только послушала тебя…";
                                string door_6811 = "- Ты не виновата. Я должен был подумать о нашей безопасности…";
                                string door_6812 = "- Я так рада… ";
                                string door_6813 = "<i>В порыве чувств она обняла меня. Я не мог не ответить на ее объятия.</i>";
                                string door_6814 = "- Как я мог?.. Как я мог тебя забыть?..";
                                string door_6815 = "<i>Юи плакала. Я тоже.\n\nНе знаю, сколько времени прошло…</i>";
                                string door_6816 = "- Уже темнеет… Может… Может зайдешь ко мне домой?..";
                                string door_6817 = "<i>Я не видел ее лица за маской, но был уверен, что она покраснела. Я сглотнул.</i>";
                                string door_6818 = "- Хорошо…";
                                string door_6819 = "<i>Она до последнего не снимала маску. Я не знал, почему, но решил не спрашивать.\n\nМы пили чай, потом ужинали.\n\nНам не нужно было разговаривать.\n\nУже то, что она была рядом, согревало меня. Я уже совсем забыл про дверь, про нож и все предупреждения Дмитрия…\n\nВсе это было не о ней. Это другая Юи…\n\nКогда я увидел ее лицо, что-то внутри меня щелкнуло.\n\nЯ не мог ее не поцеловать…</i>";
                                string door_6910 = "<i>Постельная сцена</i>";
                                string door_6911 = "<i>Мы уснули в обнимку, но, проснувшись, я не обнаружил ее рядом со мной.\n\nЯ решил, что она отошла на кухню…\n\nЕще была ночь, поэтому вместо нее я натолкнулся на другую комнату…\n\nДверь оказалась не заперта, поэтому я вошел внутрь…\n\nБыло темно, под ногами что-то неприятно чавкало. Подошва липла к полу… Это была кровь…\n\nМеня едва не вывернуло от запаха разлагающейся плоти и ужаса представшей передо мной картины…\n\nКомната была завалена человеческими телами...\n\n Сперва я не различал их, но затем, сквозь раны и кровь я смог рассмотреть их черты…</i>";
                                string door_6912 = "- Алена! Аня! Жанна! Ира! Даже Витя!";
                                string door_6913 = "<i>Крик мой был тихим, словно приглушенным. Голос предательски дрожал…\n\nКак это могло произойти?..\n\nНет… Только не это… Это не может быть правдой!\n\nНужно бежать!!!</i>";
                                string door_6914 = "- Не так быстро…";
                                string door_6915 = "<i>Это была Юи, но не совсем она. Я не знал, как это объяснить. Голос, поведение, даже сознание… Это не та Юи, которую я знал…\n\nСтрах, картина той самой двери, слова Дмитрия – все это снова всплыло в моей голове…</i>";
                                string door_6916 = "- Зря ты пришел сюда… Очень зря… А ведь все шло так хорошо…";
                                string door_6917 = "<i>Я отступил назад, но натолкнулся на одно из тел…</i>";
                                string door_6918 = "- Это сделала ты? Ты убила их?";
                                string door_6919 = "- Зачем спрашивать, если знаешь ответ на свой вопрос?";
                                string door_6100 = "- Но зачем?! Зачем ты сделала это?! Как ты могла?!";
                                string door_6101 = "- Я?.. Это ты их убил… Ты позволил им быть рядом, позволил прикасаться к тебе… Я любила тебя… Но ты забыл меня… Я все делала, чтобы тебя вернуть, а ты видел лишь их… Это не моя вина!";
                                string door_6102 = "<i>Она достала нож – тот самый, что я взял для самозащиты, и побежала на меня. В последний момент мне удалось оттолкнуть ее и скрыться из комнаты…\n\nЯ выбежал из квартиры и побежал на крышу, надеясь спрятаться…\n\nЯ слышал ее шаги – медленные, уверенные. Так передвигается хищник перед зловещим маневром. Она была уверена в победе… </i>";
                                string door_6103 = "- Миша… Выходи… Я же знаю, ты где-то здесь… Ты знаешь, от меня бесполезно прятаться… Даже если ты сбежишь из этого мира, я все равно найду тебя в другом… Больше нам никто не помешает… Я убью тебя, Миш. Убью, и мы всегда будем вместе… Вечно…";
                                string door_6104 = "<i>Да она, верно, шутит! Какая же это любовь?!</i>";
                                string door_6105 = "- Нашла!..";
                                string door_6106 = "<i>Юи замахнулась ножом, но я подставил руку и перехватил ее.\n\nОна перекрыла выход.\n\nБежать некуда. Прыгать высоко. У нее оружие… Мне не спастись…\n\nТак я думал, приближаясь к краю крыши…\n\nНо в последний момент что-то случилось. Она вонзила нож себе в живот…</i>";
                                string door_6107 = "- Что ты делаешь?!";
                                string door_6108 = "<i>Прежде, чем Юи упала на землю, я успел подхватить ее.</i>";
                                string door_6109 = "- Оставь меня, Миш… Беги… Живи… Я не знаю, сколько еще смогу сдерживать ее… ";
                                string door_6110 = "<i>По ее щекам одна за другой катились слезы, а одежду заполняло пятно крови…</i>";
                                string door_6111 = "- Мне так жаль… Я… Не хотела, чтобы так вышло… Не хотела их убивать… Ведь… Они были дороги тебе, правда? Ты был так счастлив… И… Хоть я и могла только наблюдать за тобой издалека, пусть ты и не помнил меня… Ты улыбался… Я была счастлива за тебя… Я не хочу причинять тебе боль… Я ведь правда очень тебя люблю… Прости меня, Миш… Пожалуйста, прости…";
                                string door_6112 = "<i>Я схватил ее за руку.</i>";
                                string door_6113 = "- Нет! Не смей умирать, слышишь меня?! Еще все можно исправить… Все…";
                                string door_6114 = "<i>Я попытался зажать ее рану, но не смог. Она была слишком глубока… Мои руки были в крови. В крови Юи…</i>";
                                string door_6115 = "- Нужно вызвать скорую!";
                                string door_6116 = "<i>Я потянулся за телефоном, но она остановила меня.</i>";
                                string door_6117 = "- Они не успеют… Я больна, Миш… Я уже… Не могу быть собой, как раньше… Она… Слишком сильна… Если я выживу, ты больше не сможешь жить, как раньше…";
                                string door_6118 = "- Но… ";
                                string door_6119 = "- Прости меня… И прощай…";
                                string door_6120 = "<i>Ее глаза закрылись. Из тело постепенно начало уходить тепло. Я больше не чувствовал ее пульса, не слышал ее дыхания…</i>";
                                string door_6121 = "- Я и не думал, что ты выживешь…";
                                string door_6122 = "<i>Я уже привык к тому, что Дмитрий появляется из ниоткуда. </i>";
                                string door_6123 = "- Она погибла из-за меня…";
                                string door_6124 = "- Ты ничего не мог для нее сделать. Юи исчерпала себя...";
                                string door_6125 = "- Но, разве это правильно? Разве она должна была так закончить?..";
                                string door_6126 = "- Возможно это не конец…";
                                string door_6127 = "- Что ты имеешь в виду?..";
                                string door_6128 = "- Возможно, где-то там, далеко, существует альтернативная реальность, где она все еще жива…";
                                string door_6129 = "- Значит она, как и я, будет ходить по мирам, забудет все?";
                                string door_6130 = "- Не исключено… Но, если и так, что ты собираешься делать?";
                                string door_6131 = "- А что я могу?";
                                string door_6132 = "<i>Я поднял на него взгляд.</i>";
                                string door_6133 = "- До этого момента Юи вмешивалась в ход событий, заставляя тебя путешествовать от двери к двери. Теперь же ты можешь сам решать свою судьбу… Остаться здесь, вернуться в один из миров, где ты бывал ранее или же отправиться за ней…";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_60, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_61, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_62, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_63, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_64, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_65, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_66, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_67, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_68, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_69, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_610, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_611, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_612, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_613, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_614, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_615, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_616, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_617, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_618, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_619, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_620, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_621, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_622, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_623, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_624, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_625, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_626, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_627, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_628, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_629, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_630, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_631, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_632, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_633, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_634, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_635, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_636, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_637, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_638, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_639, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_640, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_641, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_642, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_643, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_644, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_645, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_646, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_647, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_648, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_649, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_650, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_651, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_652, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_653, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_654, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_655, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_656, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_657, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_658, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_659, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_660, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_661, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_662, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_663, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_664, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_665, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_666, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_667, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_668, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_669, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_670, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_671, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_672, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_673, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_674, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_675, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_676, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_677, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_678, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_679, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_680, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_681, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_682, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_683, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_684, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_685, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_686, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_687, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_688, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_689, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_690, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_691, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_692, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_693, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_694, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_695, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_696, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_697, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_698, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_699, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                //problem
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6710, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6711, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6712, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6713, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6714, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6715, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6716, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6717, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6718, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6719, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6810, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6811, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6812, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6813, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6814, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6815, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6816, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6817, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6818, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6819, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6910, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6911, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6912, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6913, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6914, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6915, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6916, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6917, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6918, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6919, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                //problem fixed
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6100, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6101, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6102, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6103, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6104, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6105, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6106, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6107, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6108, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6109, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6110, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6111, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6112, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6113, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6114, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6115, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6116, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6117, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6118, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6119, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6120, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6121, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6122, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6123, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6124, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6125, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6126, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6127, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6128, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6129, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6130, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6131, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6132, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);

                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Остаться"),

                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Вернуться к Алене"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Вернуться к Ирине"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Вернуться к Анне"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Вернуться к Жанне"),
                                                },new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Отправиться за Юи"),
                                                },
                                                new[]
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                string[] keys = { "Войти в шестую дверь", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6133, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);

                            }
                            //Эпилог
                            else if (message.Text == "Перейти к эпилогу")
                            {
                                string epilog = "<i>Я никогда не задумывался о том, чего хочу… Наверное у многих сейчас это самые банальные желания, вроде успешного окончания учебы, хорошая работа, семья, любовь… Я не знаю, важно ли все это для меня… Есть ли в этом мире что-нибудь по-настоящему важное?\n\nВ мире, где каждый ищет, ради чего ему жить, смогу ли я найти это что-то когда-нибудь?..»\n\nЮи жила ради меня… Она пожертвовала всем, что у нее было, чтобы вновь встретиться со мной… Чтобы помнить меня…\n\nЯ не знаю, что меня ждет впереди…\n\nЛюди живут долго, помня то, что не хотят, и забывая то, что забывать не следует…\n\nВозможно я снова забуду что-то важное… Много важных вещей…\n\nЯ не могу ручаться даже за то, что вспомню свое имя, когда проснусь... Я не знаю, где я проснусь…\n\nНо одно я знаю наверняка…\n\nЯ найду то, ради чего мне стоит жить…</i>";
                                string end = "<i>The End</i>";
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Спасибо"),
                                                },
                                            },
                                    ResizeKeyboard = true
                                };
                                string[] keys = { "Перейти к эпилогу", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, epilog, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, end, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);
                            }
                            //дверь №6
                            else if (message.Text == "Остаться")
                            {
                                string door_6135 = "- Я… Устал… Я больше не могу путешествовать…";
                                string door_6136 = "- Я понимаю твое желание…";
                                string[] keys = { "Остаться", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                string door_6137 = "<i>С тех пор в моей жизни не случалось ничего интересного…\n\nЯ закончил университет в красным дипломом, получил престижную работу…\n\nВ скором времени я получу должность главного директора, возможно заведу семью и забуду обо всем, что случилось… \n\nНо я не хочу забывать…</i>";
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6135, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6136, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6137, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendPhotoAsync(message.Chat.Id, "https://preview.ibb.co/mCo0p6/CHOISE_61.jpg", "", false, 0, keyboard6);
                                keyboardLast = keyboard6;
                            }
                            else if (message.Text == "Вернуться к Алене")
                            {
                                string door_6139 = "- Я хочу вернуться к сестре…";
                                string door_6140 = "- Хорошо… Если ты умрешь в этом мире, ты забудешь все, что с тобой произошло, будешь жить так, как будто всего этого никогда не случалось…";
                                string door_6141 = "- Значит я забуду и Юи?..";
                                string door_6142 = "- Увы. Ты можешь выбрать лишь одну альтернативную личность, чтобы жить ее жизнью. Но для этого придется избавиться от остальных.";
                                string door_6143 = "- И я никогда не вспомню о том, что произошло?";
                                string door_6144 = "- Никогда.";
                                string door_6145 = "- Тогда… Я согласен…";
                                string door_6146 = "<i>Я сглотнул, разбежался и прыгнул, оставив все ужасы позади…</i>";
                                string[] keys = { "Вернуться к Алене", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6139, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6140, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6141, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6142, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6143, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6144, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6145, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6146, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendPhotoAsync(message.Chat.Id, "https://thumb.ibb.co/kCm9hR/CHOISE_62.jpg", "", false, 0, keyboard6);
                                keyboardLast = keyboard6;
                            }
                            else if (message.Text == "Вернуться к Ирине")
                            {
                                string door_6148 = "- Я хочу вернуться к Ирине…";
                                string door_6149 = "- Хорошо… Если ты умрешь в этом мире, ты забудешь все, что с тобой произошло, будешь жить так, как будто всего этого никогда не случалось…";
                                string door_6150 = "- Значит я забуду и Юи?..";
                                string door_6151 = "- Увы. Ты можешь выбрать лишь одну альтернативную личность, чтобы жить ее жизнью. Но для этого придется избавиться от остальных.";
                                string door_6152 = "- И я никогда не вспомню о том, что произошло?";
                                string door_6153 = "- Никогда.";
                                string door_6154 = "- Тогда… Я согласен…";
                                string door_6155 = "<i>Я сглотнул, разбежался и прыгнул, оставив все ужасы позади…</i>";
                                string[] keys = { "Вернуться к Ирине", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6148, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6149, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6150, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6151, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6152, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6153, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6154, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6155, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendPhotoAsync(message.Chat.Id, "https://thumb.ibb.co/mHffp6/CHOISE_63.jpg", "", false, 0, keyboard6);
                                keyboardLast = keyboard6;
                            }
                            else if (message.Text == "Вернуться к Анне")
                            {
                                string door_6157 = "- Я хочу вернуться к Анне…";
                                string door_6158 = "- Хорошо… Если ты умрешь в этом мире, ты забудешь все, что с тобой произошло, будешь жить так, как будто всего этого никогда не случалось…";
                                string door_6159 = "- Значит я забуду и Юи?..";
                                string door_6160 = "- Увы. Ты можешь выбрать лишь одну альтернативную личность, чтобы жить ее жизнью. Но для этого придется избавиться от остальных.";
                                string door_6161 = "- И я никогда не вспомню о том, что произошло?";
                                string door_6162 = "- Никогда.";
                                string door_6163 = "- Тогда… Я согласен…";
                                string door_6164 = "<i>Я сглотнул, разбежался и прыгнул, оставив все ужасы позади…</i>";
                                string[] keys = { "Вернуться к Анне", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6157, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6158, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6159, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6160, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6161, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6162, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6163, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6164, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendPhotoAsync(message.Chat.Id, "https://thumb.ibb.co/cOsMwm/CHOISE_64.jpg", "", false, 0, keyboard6);
                                keyboardLast = keyboard6;

                            }
                            else if (message.Text == "Вернуться к Жанне")
                            {
                                string door_6166 = "- Я хочу вернуться к Жанне…";
                                string door_6167 = "- Хорошо… Если ты умрешь в этом мире, ты забудешь все, что с тобой произошло, будешь жить так, как будто всего этого никогда не случалось…";
                                string door_6168 = "- Значит я забуду и Юи?..";
                                string door_6169 = "- Увы. Ты можешь выбрать лишь одну альтернативную личность, чтобы жить ее жизнью. Но для этого придется избавиться от остальных.";
                                string door_6170 = "- И я никогда не вспомню о том, что произошло?";
                                string door_6171 = "- Никогда.";
                                string door_6172 = "- Тогда… Я согласен…";
                                string door_6173 = "<i>Я сглотнул, разбежался и прыгнул, оставив все ужасы позади…</i>";
                                string[] keys = { "Вернуться к Жанне", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6166, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6167, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6168, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6169, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6170, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6171, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6172, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6173, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendPhotoAsync(message.Chat.Id, "https://thumb.ibb.co/fqSzhR/CHOISE_65.jpg", "", false, 0, keyboard6);
                                keyboardLast = keyboard6;
                            }
                            else if (message.Text == "Отправиться за Юи")
                            {
                                string door_6175 = "- Я… Я не могу оставить ее… Это не ее вина… Настоящая Юи где-то там, напуганная и растерянная… Я должен ее найти!";
                                string door_6176 = "- Но, если ты отправишься за ней, не лишившись памяти, с тобой произойдет то же, что и с ней…";
                                string door_6177 = "- Но как я найду Юи, не помня ее?";
                                string door_6178 = "- Я могу оставить тебе память о ней. О других альтернативных мирах ты забудешь.";
                                string door_6179 = "- Но…";
                                string door_6180 = "- Ты готов рискнуть ее жизнью? ";
                                string door_6181 = "<i>Я опустил голову.\n\nЕсли переход между мирами оставляет такой отпечаток на сознании, я не могу так рисковать.</i>";
                                string door_6182 = "- Я согласен.";
                                string door_6183 = "- Что-ж, это твой выбор.";
                                string door_6184 = "- Что мне делать?";
                                string door_6185 = "- Если ты умрешь в этом мире, ты забудешь все, что с тобой произошло, будешь жить так, как будто всего этого никогда не случалось…";
                                string door_6186 = "- Значит я забуду Алену, Аню, Иру, Жанну и даже Витю?..";
                                string door_6187 = "- Увы. Ты можешь выбрать лишь одну альтернативную личность, чтобы жить ее жизнью. Но для этого придется избавиться от остальных…";
                                string door_6188 = "- И я никогда не вспомню о том, что произошло?";
                                string door_6189 = "- Никогда.";
                                string door_6190 = "- Тогда… Я согласен…";
                                string door_6191 = "<i>Я сглотнул, разбежался и прыгнул, оставив все ужасы позади…</i>";
                                string[] keys = { "Отправиться за Юи", "/help" };
                                Keys_to_file(message.Chat.Id, keys);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6175, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6176, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6177, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6178, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6179, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6180, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6181, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6182, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6183, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6184, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6185, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6186, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6187, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6188, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6189, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6190, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendTextMessageAsync(message.Chat.Id, door_6191, false, false, 0, null, ParseMode.Html); Thread.Sleep(4000);
                                await Bot.SendPhotoAsync(message.Chat.Id, "https://thumb.ibb.co/dtcX2R/CHOISE_66.jpg", "", false, 0, keyboard6);
                                keyboardLast = keyboard6;
                            }
                            else if (message.Text == "Спасибо") { }
                            else
                            {
                                string opisanie = "Текст предупреждения\n";
                                // в ответ на команду /saysomething выводим сообщение
                                await Bot.SendTextMessageAsync(message.Chat.Id, opisanie, false, false, 0, keyboardLast, ParseMode.Html);

                            }
                        }
                    }
                    catch(Exception p)
                    {
                        List<string> a = new List<string>();
                        a = Keys_out_file(message.Chat.Id);
                        var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                        {
                            Keyboard = new[] {
                                new[]{
                                    new Telegram.Bot.Types.KeyboardButton(null)
                                },
                            },
                            ResizeKeyboard = true
                        };
                        
                        
                        if (a.Count == 1)
                        {
                            keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                        }
                        else if (a.Count == 2)
                        {
                            keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                        }
                        else if (a.Count == 3)
                        {
                            keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[2])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                        }
                        else if (a.Count == 4)
                        {
                            keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[2])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[3])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                        }
                        else if (a.Count == 5)
                        {
                            keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[2])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[3])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[4])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                        }

                        else if (a.Count == 6)
                        {
                            keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[0])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[1])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[2])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[3])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[4])
                                                },
                                            new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton(a[5])
                                                },
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                        }
                        await Bot.SendTextMessageAsync(message.Chat.Id, "Внимание, произошла задержка загрузки игры. Для продолжения выберите вариант заново", false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(4000);
                    }
                };

                // запускаем прием обновлений
                Bot.StartReceiving();
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message); // если ключ не подошел - пишем об этом в консоль отладки
            }

        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            var text = @txtKey.Text; // получаем содержимое текстового поля txtKey в переменную text
            if (text != "" && this.bw.IsBusy != true)
            {
                this.bw.RunWorkerAsync(text); // передаем эту переменную в виде аргумента методу bw_DoWork
                BtnRun.Text = "Бот запущен...";
            }
        }
    }
}
