using System.Text;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(TMP_Text))]
    public class Demo:MonoBehaviour
    {
        
        private TMP_Text txtOut;

        void Start()
        {
            txtOut = GetComponent<TMP_Text>();
        
            ShowMyStuff();
        }
        
        void ShowMyStuff()
        {
            var records = CSVManager.ReadFile(Application.streamingAssetsPath + "/conteudo_.csv");
            StringBuilder sb = new StringBuilder();
            
            foreach (var record in records)
            {
                sb.Append($"categoria: {record.Categoria}\n texto: {record.Texto}\n ===========\n");
                Debug.Log($"categoria: {record.Categoria}\n texto: {record.Texto}\n ===========\n");
            }
            
            txtOut.text = sb.ToString();

        }
    }
}