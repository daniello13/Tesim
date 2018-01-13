using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                            string prolog = "<i>Пролог \n Во времена, когда все люди были одинаковы, а дни были похожи на все предыдущие, кто-то сказал: «Я хочу измениться». Он первый дал толчок развитию. И тогда другие задумались: «Неужели я хуже него? Неужели я не могу измениться?..»\nНо прошло время.  Одни люди развивались медленнее, другие – быстрее. Подобно звездам, одни разгорались ярче других. И тогда родилась зависть…\nТе, что горели слабее других, начали смеяться над другими. Порой тьма в их сердцах была так сильна, что толкала на ужасающие поступки. Люди начали бояться «гореть»…\nВ страхе стать высмеянными и униженными отверженцами, они остановились. С каждым днем свет искр в их сердцах все тускнел и тускнел, до тех пор, пока не померк вовсе…\nЛюди снова стали похожими и одинаковыми. Мир стал грозовым  небом, которое заволокли тучи… Человеческие мечты, словно большие капли, переполненные боли, печали и отчаяния, начали срываться вниз…\nНо далеко не все были готовы с этим смириться. И тогда кто-то сказал: «Я выдержу!» - так родилась смелость. Она огромной молнией в один миг прорезала и озарила небосвод человеческих душ…\nЭто никому не понравилось… Капли все падали и падали, дождь перерос в град, желая покорить выскочку, но он не был одним… Вслед за ним небо прорезали и другие молнии. Их было совсем немного, но сила их сердец была настолько велика, что тучи отступили… В человеческих сердцах вновь загорелись звезды. Сперва их свет был едва заметен, но с годами они разгорались все ярче и их свет дал рождение новой эпохе. Эпохе, в которую никто не боялся «гореть»…\n«Интересно, смогу ли я стать таким же? Сейчас каждый мой день похож на предыдущий. Смогу ли я победить свои страхи, страхи других людей и «гореть» так же ярко, как сердца людей в легенде? Смогу ли я измениться?\nЯ никогда не задумывался о том, чего хочу… Наверное у многих сейчас это самые банальные желания, вроде успешного окончания учебы, хорошая работа, семья, любовь… Я не знаю, важно ли все это для меня… Есть ли в этом мире что-нибудь по-настоящему важное? \nВ мире, где каждый ищет, ради чего ему жить, смогу ли я найти это что-то когда-нибудь?..»</i>\n";
                            // в ответ на команду /saysomething выводим сообщение
                            await Bot.SendTextMessageAsync(message.Chat.Id, prolog, false, false,0,null,ParseMode.Html);
                        }
                        if (message.Text == "/getimage")
                        {
                            // в ответ на команду /getimage выводим картинку
                            await Bot.SendPhotoAsync(message.Chat.Id, "http://aftamat4ik.ru/wp-content/uploads/2017/03/photo_2016-12-13_23-21-07.jpg", "Revolution!");
                        }

                        // inline buttons
                        if (message.Text == "/ibuttons")
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

                        // reply buttons
                        if (message.Text == "/rbuttons")
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
                        if (message.Text.ToLower() == "накатим!")
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Ну, за охоту!", replyToMessageId: message.MessageId);
                        }
                        if (message.Text.ToLower() == "рря!")
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Ну, за демократию!", replyToMessageId: message.MessageId);
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
