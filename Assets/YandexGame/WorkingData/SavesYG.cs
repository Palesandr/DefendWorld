
using Unity.VisualScripting.Antlr3.Runtime.Tree;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int isStartGame = 1;                       // Можно задать полям значения по умолчанию
        public int isDead = 0;
        public int LevelID = 1;
        public int isWinLevel = 0;
        public int skinID = 0;
        //public int Life = 0;
        public int money = 0;
        public float healthShield = 10;
        public float maxHealthShield = 10;
        public int damageBullet = 1;
        public float speedBullet = 1;
        public int speedPlayer = 8;
        public float maxUP = 0;
        public float updBullet = 10;
        public float healthPlayer = 0;
        public float maxHealthPlayer = 0;
        public int countBomb = 5;
        public int finallyScore = 0;
        public int finallyCountEnemy = 0;



        // Ваши сохранения

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны
        // Пока выявленное ограничение - это расширение массива


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            //openLevels[1] = true;

            // Длина массива в проекте должна быть задана один раз!
            // Если после публикации игры изменить длину массива, то после обновления игры у пользователей сохранения могут поломаться
            // Если всё же необходимо увеличить длину массива, сдвиньте данное поле массива в самую нижнюю строку кода
        }
    }
}
