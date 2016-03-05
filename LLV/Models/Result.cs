using System.Linq;

namespace LLV.Models
{
    public class Result<TData>
    {
        private readonly ResultModel<TData> _resultModel;

        public Result()
        {
            _resultModel = new ResultModel<TData>();
        }

        public void AddError(string message)
        {
            _resultModel.Errors.Add(message);
        }

        public void SetResult(TData data)
        {
            _resultModel.Data = data;
        }

        public bool IsOK
        {
            get
            {
                return false == _resultModel.Errors.Any();
            }
        }

        public ResultModel<TData> Resolve()
        {
            if (_resultModel.Errors.Any())
            {
                _resultModel.OK = false;
                _resultModel.Data = default(TData);
            }
            else
            {
                _resultModel.OK = true;
            }

            return _resultModel;
        }

        public ResultModel<TData> Empty()
        {
            _resultModel.OK = true;

            _resultModel.Data = default(TData);

            return _resultModel;
        }
    }

    public class Result
    {
        private readonly ResultModel _resultModel;

        public Result()
        {
            _resultModel = new ResultModel();
        }

        public void AddError(string message)
        {
            _resultModel.Errors.Add(message);
        }

        public bool IsOK
        {
            get
            {
                return false == _resultModel.Errors.Any();
            }
        }

        public ResultModel Resolve()
        {
            _resultModel.OK = !_resultModel.Errors.Any();

            return _resultModel;
        }
    }
}