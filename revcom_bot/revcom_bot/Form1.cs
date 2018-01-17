using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
                                                    new Telegram.Bot.Types.KeyboardButton("Войти во четвертую дверь"),
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

                    if (message == null) return;
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
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                            keyboardLast = keyboard;
                            await Bot.SendTextMessageAsync(message.Chat.Id, prolog, false, false,0, keyboard, ParseMode.Html);
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
                                                    new Telegram.Bot.Types.KeyboardButton("/help")
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                            keyboardLast = keyboard;
                            await Bot.SendTextMessageAsync(message.Chat.Id, Room_with_doors, false, false, 0, keyboard, ParseMode.Html);
                        }
                        else if (message.Text == "Ожидайте загрузки квеста"){

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
                            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadAudio);

                            const string file = @"opening.mp3";

                            var fileName = file.Split(Path.DirectorySeparatorChar).Last();

                            using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                await Bot.SendAudioAsync(
                                    message.Chat.Id,
                                    new Telegram.Bot.Types.FileToSend("opening.mp3", fileStream),
                                    150,
                                    "Pixie",
                                    "Opening",false,0,null
                                    );
                            }
                            
                            string door11 = "<i>Шагнув через порог, я оказался на лестничной клетке перед другой дверью. Не знаю, как это произошло. Кажется, я нахожусь в каком то здании. \n\n Я не помню, чтобы звонил или стучал в дверь, но там, с той стороны, послышались приближающиеся шаги. Через пару секунд она распахнулась и передо мной оказалась милая длинноволосая брюнетка с карими глазами. Она была среднего роста.</i>";
                            Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door11, false, false, 0, keyboardWait, ParseMode.Html);
                            string door12 = "- Братик?";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door12, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            string door13 = "- Братик?..  – <i>недоуменно переспросил я. \n\nНеужели эта девушка – моя сестра?</i>";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door13, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            string door14 = "<i>Она оценивающе посмотрела на меня, в мгновение ока изменившись в лице.  Мне это не понравилось. Взгляд стал суровым. Не успел я опомниться, как та, которую я несколько минут назад опрометчиво посчитал милашкой, размахнулась и изо всех сил врезала мне по лицу кулаком. Да так, что я чуть было не потерял равновесие.</i>";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door14, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            string door_15 = "- Снова пил со своими друзьями?! А я-то волновалась, думала, где же ты шастал всю ночь, а оно вот как! Это же до каких соплей и чертиков нужно было напиться, чтобы сестру родную не признать?! Небось и имени моего не помнишь?!  - <i>я виновато посмотрел на нее и она тяжело выдохнула</i>.";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_15, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            string door_16 = "- Прости, я совершенно ничего не помню. Не знаю, что произошло.";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_16, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            string door_17 = "-Серьезно ? – <i> брюнетка еще какое-то время сверлила меня недоверчивым взглядом, а затем смирилась.Даже выражение ее лица стало более мягким, я бы сказал несколько обеспокоенным </i>.";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_17, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            string door_18 = "-Мне очень жаль.";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_18, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
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
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_111, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_112, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_113, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_114, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_115, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_116, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_117, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_118, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_119, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_120, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_121, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_122, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_123, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_124, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_125, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_126, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_127, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_128, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_129, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_130, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_131, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_132, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_133, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_134, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_135, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_136, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_137, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_138, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_139, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_140, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_141, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_142, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_143, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_144, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_145, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_146, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_147, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_148, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_149, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_150, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_151, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_152, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_153, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_154, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_155, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_156, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_157, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_158, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_159, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_160, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_161, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_162, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_163, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_164, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_165, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_166, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_167, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_168, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_169, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_170, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_171, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_172, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_173, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_174, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_175, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_176, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_177, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_178, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_179, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_180, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_181, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_182, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_183, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_184, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_185, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_186, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_187, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_188, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_189, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_190, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_191, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_192, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_193, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_194, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_195, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_196, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_197, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_198, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_199, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1100, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1101, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1102, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1103, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1104, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1105, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1106, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1107, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1108, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1109, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1110, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1111, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            
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
                            keyboardLast = keyboard;
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1112, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(52);

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
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1113, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1114, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1115, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1116, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1117, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1118, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1119, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1120, false, false, 0, keyboardDoor2, ParseMode.Html); Thread.Sleep(52);

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
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1121, false, false, 0, keyboardDoor2, ParseMode.Html); Thread.Sleep(52);

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
                            
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1123, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1124, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1125, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1126, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1127, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1128, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1129, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1130, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1131, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1132, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1133, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1134, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1135, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1136, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1137, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_1138, false, false, 0, keyboardDoor2, ParseMode.Html); Thread.Sleep(52);

                        }
                        else if (message.Text == "Авторы" || message.Text == "авторы")
                        {
                            
                            await Bot.SendPhotoAsync(message.Chat.Id, "https://preview.ibb.co/gsmpCR/pasha.jpg", "Вы нашли пасхалочку, заботливо подготовленную для Вас авторами. \n\nМы, Amadei, Znahar");
                        }
                        // inline buttons
                        else if (message.Text == "/ibuttons")
                        {
                            var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(
                                                    new Telegram.Bot.Types.InlineKeyboardButton[][]
                                                    {
                                                            // First row
                                                            new [] {
                                                                // First column
                                                                new Telegram.Bot.Types.InlineKeyboardButton("раз","callback1"),

                                                                // Second column
                                                                new Telegram.Bot.Types.InlineKeyboardButton("два","callback2"),
                                                            },
                                                    }
                                                );

                            await Bot.SendTextMessageAsync(message.Chat.Id, "Давай накатим, товарищ, по одной!", false, false, 0, keyboard, Telegram.Bot.Types.Enums.ParseMode.Default);
                        }
                        else if(message.Text == "/help")
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Этот бот служит для игрового процесса в текствовoм квесте, в чате ничего не пишите что бы не спойлерить себе игру, читайте текст, и ждите кнопок", false, false, 0, null, Telegram.Bot.Types.Enums.ParseMode.Default);
                        }
                        // reply buttons
                        else if (message.Text == "/rbuttons")
                        {
                            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Накатим!"),
                                                    new Telegram.Bot.Types.KeyboardButton("Рря!")
                                                },
                                            },
                                ResizeKeyboard = true
                            };

                            await Bot.SendTextMessageAsync(message.Chat.Id, "Давай накатим, товарищ, мой!", false, false, 0, keyboard, Telegram.Bot.Types.Enums.ParseMode.Default);
                        }
                        // обработка reply кнопок
                        else if (message.Text.ToLower() == "накатим!")
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Ну, за охоту!", replyToMessageId: message.MessageId);
                        }
                        else if (message.Text.ToLower() == "рря!")
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Ну, за демократию!", replyToMessageId: message.MessageId);
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
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_20, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_21, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_22, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_23, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_24, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_25, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_26, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_27, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_28, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_29, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_210, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_211, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_212, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_213, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_214, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_215, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_216, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_217, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_218, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_219, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_220, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_221, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_222, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_223, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_224, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_225, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_226, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_227, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_228, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_229, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_230, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_231, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_232, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_233, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_234, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_235, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_236, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_237, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_238, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_239, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_240, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_241, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_242, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_243, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_244, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_245, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_246, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_247, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_248, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_249, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_250, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_251, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_252, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_253, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_254, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_255, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_256, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_257, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_258, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_259, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_260, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_261, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_262, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_263, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_264, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_265, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_266, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_267, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_268, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_269, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_270, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_271, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_272, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_273, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
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
                            keyboardLast = keyboard;
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_274, false, false, 0, keyboard, ParseMode.Html); Thread.Sleep(52);

                        }
                        else if (message.Text == "Остановить")
                        {
                            string door_276 = "- Разве ты хочешь этого?";
                            string door_277 = "- Что? Нет! Конечно не хочу! Но… Что я могу? ";
                            string door_278 = "- Скажи им, что хочешь остаться, что не хочешь уезжать. Ты уже совершеннолетняя, ты можешь жить здесь и одна.";
                            string door_279 = "- Они против этого… Считают, опасно оставлять меня одну здесь.";
                            string door_280 = "- Но ты ведь не одна здесь. У тебя есть я.";
                            string door_281 = "- Ты прав… Возможно, если бы ты поговорил с ними, они позволили бы мне остаться здесь… Но… Ты правда пойдешь на это?...";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_276, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_277, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_278, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_279, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_280, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_281, false, false, 0, keyboardDoor3, ParseMode.Html); Thread.Sleep(52);
                        }
                        else if (message.Text == "Согласиться")
                        {
                            string door_282 = "- А почему нет? Глупо не попытаться…";
                            string door_283 = "<i>Вечером мы пили чай в напряженном молчании, дожидаясь возвращения ее родителей. Я не знал, получится ли у меня, но попробовать стоило.\n\nРазговор был долгим и тяжелым. Они оба выслушали меня, сопоставив все «за» и «против». Отец Иры долго буравил меня взглядом, но я держался. Я ведь действительно не собирался причинять ей зло.\n\nВ конце концов, после нашего разговора, они не остыли полностью, но попробовать согласились.\n\nИрина останется здесь на месяц и, если не будет никаких проблем, она сможет и дальше жить здесь.\n\nКогда родители ушли вновь, Ира радостно кинулась мне на шею.</i>";
                            string door_284 = "- Слава Богу! Господи, Миш, как же я рада! Спасибо тебе!";
                            string door_285 = "- Ладно тебе. Все уже позади. Рада, что остаешься?";
                            string door_286 = "- Очень! Очень рада! Спасибо тебе огромное!";
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_282, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_283, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_284, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_285, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_286, false, false, 0, keyboardDoor3, ParseMode.Html); Thread.Sleep(52);

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
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_287, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_288, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_289, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_290, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_291, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_292, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_293, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_294, false, false, 0, keyboardDoor3, ParseMode.Html); Thread.Sleep(52);

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
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_296, false, false, 0, keyboardWait, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_297, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_298, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_299, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_2100, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_2101, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_2102, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_2103, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_2104, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_2105, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_2106, false, false, 0, null, ParseMode.Html); Thread.Sleep(52);
                            await Bot.SendTextMessageAsync(message.Chat.Id, door_2107, false, false, 0, keyboardDoor3, ParseMode.Html); Thread.Sleep(52);

                        }

                        else
                        {
                            string opisanie = "Текст предупреждения\n";
                            // в ответ на команду /saysomething выводим сообщение
                            await Bot.SendTextMessageAsync(message.Chat.Id, opisanie, false, false, 0, keyboardLast, ParseMode.Html);

                        }
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
