using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoardService: BaseModelService<Board>
{
    public BoardService(): base(StorePaths.Board) { }
}
