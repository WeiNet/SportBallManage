using System;
using System.Collections.Generic;
using System.Text;


    /// <summary>
    /// ʵ����KFB_SETUPSS ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class KFB_SETUPSS
    {
        public KFB_SETUPSS()
        { }
        #region Model
        private string _n_hydh;
        private decimal? _n_dyty;
        private decimal? _n_dydz;
        private decimal? _n_dydc;
        /// <summary>
        /// 
        /// </summary>
        public string N_HYDH
        {
            set { _n_hydh = value; }
            get { return _n_hydh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DYTY
        {
            set { _n_dyty = value; }
            get { return _n_dyty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DYDZ
        {
            set { _n_dydz = value; }
            get { return _n_dydz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? N_DYDC
        {
            set { _n_dydc = value; }
            get { return _n_dydc; }
        }
        #endregion Model

    }

