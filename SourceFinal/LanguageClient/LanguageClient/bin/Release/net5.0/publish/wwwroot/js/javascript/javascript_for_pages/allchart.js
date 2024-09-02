/* ==============LANGUAGE_ANALYSIS================  */
$(function () {
  "use strict";
  var Data_Source_Language = {
    datasets: [
      {
        backgroundColor: [
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
        ],
        borderColor: [
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
          "rgba(255, 99, 132, 1)",
        ],
        borderWidth: 1,
        fill: false,
      },
    ],
  };

  var Data_Target_Language = {
    labels: ["UK", "English", "Thailand", "Chile", "Brazil", "South Africa"],
    datasets: [
      {
        label: "# of Votes",
        data: [2, 7, 3, 1, 2, 3],
        backgroundColor: [
          "rgba(255, 99, 132, 0.2)",
          "rgba(54, 162, 235, 0.2)",
          "rgba(255, 206, 86, 0.2)",
          "rgba(75, 192, 192, 0.2)",
          "rgba(153, 102, 255, 0.2)",
          "rgba(255, 159, 64, 0.2)",
        ],
        borderColor: [
          "rgba(255,99,132,1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
        ],
        borderWidth: 1,
        fill: false,
      },
    ],
  };
  var options = {
    scales: {
      yAxes: [
        {
          ticks: {
            beginAtZero: true,
          },
        },
      ],
    },
    legend: {
      display: false,
    },
    elements: {
      point: {
        radius: 0,
      },
    },
  };
  if ($("#barChart_Source_Language").length) {
    var barChartCanvas = $("#barChart_Source_Language").get(0).getContext("2d");
    var sourceLanguageData = JSON.parse(
      $("#barChart_Source_Language").attr("data-source-language")
    );

    // Cập nhật màu nền và màu viền từ Data_Source_Language
    sourceLanguageData.datasets[0].backgroundColor =
      Data_Source_Language.datasets[0].backgroundColor;
    sourceLanguageData.datasets[0].borderColor =
      Data_Source_Language.datasets[0].borderColor;

    var barChart = new Chart(barChartCanvas, {
      type: "bar",
      data: sourceLanguageData,
      options: options,
    });
  }
  if ($("#barChart_Target_Language").length) {
    var barChartCanvas = $("#barChart_Target_Language").get(0).getContext("2d");
    var chartData = JSON.parse(
      $("#barChart_Target_Language").attr("data-chart-data")
    );
    chartData.datasets[0].backgroundColor =
      Data_Source_Language.datasets[0].backgroundColor;
    chartData.datasets[0].borderColor =
      Data_Source_Language.datasets[0].borderColor;
    var barChart = new Chart(barChartCanvas, {
      type: "bar",
      data: chartData,
      options: options,
    });
  }
});
/* ==============LANGUAGE_ANALYSIS================  */
$(function () {
  "use strict";
  var Data_User_Gender = {
    labels: ["Female", "Male", "User Specified"],
    datasets: [
      {
        label: "Gender",
        data: [40.2, 59.6, 1],
        backgroundColor: ["rgba(224, 55, 112, 1)", "rgba(54, 162, 235, 1)"],
        borderColor: ["rgba(255,99,132,1)", "rgba(54, 162, 235, 1)"],
        borderWidth: 1,
        fill: false,
      },
    ],
  };
  var Data_User_Age = {
    labels: [
      "13 - 17 years",
      "18 - 24 years",
      "25 - 34 years",
      "35 - 44 years",
      "45 - 54 years",
      "55 - 64 years",
      "65+ years",
    ],
    datasets: [
      {
        label: "# of Votes",
        data: [1, 35.9, 47.3, 12.3, 2.5, 0.7, 0.4],
        backgroundColor: [
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(54, 162, 235, 1)",
        ],
        borderColor: [
          "rgba(255,99,132,1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
          "rgba(54, 162, 235, 1)",
        ],
        borderWidth: 1,
        fill: false,
      },
    ],
  };
  var Data_User_Comes_From = {
    datasets: [
      {
        data: [37.2, 25.6, 17.4, 7.9, 6.8, 5.1],
        backgroundColor: [
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
        ],
        borderColor: [
          "rgba(255,99,132,1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
        ],
      },
    ],

    labels: ["India", "Viet Nam", "Germany", "Finland", "South Korea", "Other"],
  };
  var Data_User_Goes_To = {
    datasets: [
      {
        data: [48.2, 36.9, 8.1, 4, 2.8],
        backgroundColor: [
          "rgba(255, 99, 132, 0.5)",
          "rgba(54, 162, 235, 0.5)",
          "rgba(255, 206, 86, 0.5)",
          "rgba(75, 192, 192, 0.5)",
          "rgba(153, 102, 255, 0.5)",
          "rgba(255, 159, 64, 0.5)",
        ],
        borderColor: [
          "rgba(255,99,132,1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
        ],
      },
    ],

    labels: [
      "Thailand",
      "China",
      "Sinagepore",
      "Australia",
      "Viet Nam",
      "Other",
    ],
  };
  var options = {
    scales: {
      yAxes: [
        {
          ticks: {
            beginAtZero: true,
          },
        },
      ],
    },
    legend: {
      display: false,
    },
    elements: {
      point: {
        radius: 0,
      },
    },
  };
  var doughnutPieOptions = {
    responsive: true,
    animation: {
      animateScale: true,
      animateRotate: true,
    },
  };
  // Get context with jQuery - using jQuery's .get() method.
  if ($("#barChart_User_Gender").length) {
    var barChartCanvas = $("#barChart_User_Gender").get(0).getContext("2d");
    var chartData = JSON.parse(
      $("#barChart_User_Gender").attr("data-chart-data")
    );
    console.log(chartData);
    chartData.datasets[0].backgroundColor =
      Data_User_Gender.datasets[0].backgroundColor;
    chartData.datasets[0].borderColor =
      Data_User_Gender.datasets[0].borderColor;
    var barChart = new Chart(barChartCanvas, {
      type: "bar",
      data: chartData,
      options: options,
    });
  }
  if ($("#barChart_User_Age").length) {
    var barChartCanvas = $("#barChart_User_Age").get(0).getContext("2d");
    var chartData = JSON.parse($("#barChart_User_Age").attr("data-chart-data"));
    chartData.datasets[0].backgroundColor =
      Data_User_Age.datasets[0].backgroundColor;
    chartData.datasets[0].borderColor = Data_User_Age.datasets[0].borderColor;
    var barChart = new Chart(barChartCanvas, {
      type: "bar",
      data: chartData,
      options: options,
    });
  }
  if ($("#barChart_User_Comes_From").length) {
    var doughnutChartCanvas = $("#barChart_User_Comes_From")
      .get(0)
      .getContext("2d");
    var chartData = JSON.parse(
      $("#barChart_User_Comes_From").attr("data-chart-data")
    );
    chartData.datasets[0].backgroundColor =
      Data_User_Comes_From.datasets[0].backgroundColor;
    chartData.datasets[0].borderColor =
      Data_User_Comes_From.datasets[0].borderColor;
    var doughnutChart = new Chart(doughnutChartCanvas, {
      type: "doughnut",
      data: chartData,
      options: doughnutPieOptions,
    });
  }
  if ($("#barChart_User_Goes_To").length) {
    var doughnutChartCanvas = $("#barChart_User_Goes_To")
      .get(0)
      .getContext("2d");
    var chartData = JSON.parse(
      $("#barChart_User_Goes_To").attr("data-chart-data")
    ); // Tr�ch xu?t v� chuy?n ??i d? li?u t? thu?c t�nh data-chart-data
    chartData.datasets[0].backgroundColor =
      Data_User_Goes_To.datasets[0].backgroundColor; // G�n m�u n?n t? Data_User_Comes_From
    chartData.datasets[0].borderColor =
      Data_User_Goes_To.datasets[0].borderColor;
    var doughnutChart = new Chart(doughnutChartCanvas, {
      type: "doughnut",
      data: chartData,
      options: doughnutPieOptions,
    });
  }
});
/* ==============ACCOUNT_ANALYSIS================  */
$(function () {
  "use strict";
  var LineData__User_Registration = {
    labels: [
      "1 Feb 2024",
      "6 Feb 2024",
      "10 Feb 2024",
      "15 Feb 2024",
      "24 Feb 2024",
      "28 Feb 2024",
    ],
    datasets: [
      {
        label: "# of Votes",
        data: [15, 35, 245, 524, 912, 8000],
        backgroundColor: [
          "rgba(255, 99, 132, 0.2)",
          "rgba(54, 162, 235, 0.2)",
          "rgba(255, 206, 86, 0.2)",
          "rgba(75, 192, 192, 0.2)",
          "rgba(153, 102, 255, 0.2)",
          "rgba(255, 159, 64, 0.2)",
        ],
        borderColor: [
          "rgba(255,99,132,1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
        ],
        borderWidth: 1,
        fill: false,
      },
    ],
  };
  var LineData__Numbers_of_Access = {
    labels: [
      "1 Feb 2024",
      "6 Feb 2024",
      "10 Feb 2024",
      "15 Feb 2024",
      "24 Feb 2024",
      "28 Feb 2024",
    ],
    datasets: [
      {
        label: "# of Votes",
        data: [210, 901, 5012, 14081, 31250, 77240],
        backgroundColor: [
          "rgba(255, 99, 132, 0.2)",
          "rgba(54, 162, 235, 0.2)",
          "rgba(255, 206, 86, 0.2)",
          "rgba(75, 192, 192, 0.2)",
          "rgba(153, 102, 255, 0.2)",
          "rgba(255, 159, 64, 0.2)",
        ],
        borderColor: [
          "rgba(255,99,132,1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)",
          "rgba(255, 159, 64, 1)",
        ],
        borderWidth: 1,
        fill: false,
      },
    ],
  };
  var LineData__Access_Time = {
    labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
    datasets: [
      {
        label: "Facebook",
        data: [8, 11, 13, 15, 12, 13, 16, 15, 13, 19, 11, 14],
        borderColor: ["rgba(255, 99, 132, 0.5)"],
        backgroundColor: ["rgba(255, 99, 132, 0.5)"],
        borderWidth: 1,
        fill: true,
      },
      {
        label: "Twitter",
        data: [7, 17, 12, 16, 14, 18, 16, 12, 15, 11, 13, 9],
        borderColor: ["rgba(54, 162, 235, 0.5)"],
        backgroundColor: ["rgba(54, 162, 235, 0.5)"],
        borderWidth: 1,
        fill: true,
      },
      {
        label: "Linkedin",
        data: [6, 14, 16, 20, 12, 18, 15, 12, 17, 19, 15, 11],
        borderColor: ["rgba(255, 206, 86, 0.5)"],
        backgroundColor: ["rgba(255, 206, 86, 0.5)"],
        borderWidth: 1,
        fill: true,
      },
    ],
  };

  var options = {
    scales: {
      yAxes: [
        {
          ticks: {
            beginAtZero: true,
          },
        },
      ],
    },
    legend: {
      display: false,
    },
    elements: {
      point: {
        radius: 0,
      },
    },
  };
  var multiAreaOptions = {
    plugins: {
      filler: {
        propagate: true,
      },
    },
    elements: {
      point: {
        radius: 0,
      },
    },
    scales: {
      xAxes: [
        {
          gridLines: {
            display: false,
          },
        },
      ],
      yAxes: [
        {
          gridLines: {
            display: false,
          },
        },
      ],
    },
  };
  if ($("#lineChart_User_Registration").length) {
    var lineChartCanvas = $("#lineChart_User_Registration")[0].getContext("2d");
    var lineChartData = $("#lineChart_User_Registration").data(
      "line-chart-data"
    );
    var lineChartLabels = $("#lineChart_User_Registration").data(
      "line-chart-labels"
    );
    var lineChartOptions = $("#lineChart_User_Registration").data(
      "line-chart-options"
    );

    var lineChart = new Chart(lineChartCanvas, {
      type: "line",
      data: {
        labels: lineChartLabels,
        datasets: [
          {
            label: "User Registration",
            data: lineChartData,
            borderColor: "#627254", // Đổi màu thành đỏ
            borderWidth: 2,
          },
        ],
      },
      options: lineChartOptions,
    });
  }
  if ($("#lineChart_Numbers_of_Access").length) {
    var lineChartCanvas = $("#lineChart_Numbers_of_Access")[0].getContext("2d");
    var lineChartData = $("#lineChart_Numbers_of_Access").data(
      "line-chart-data"
    );
    var lineChartOptions = $("#lineChart_Numbers_of_Access").data(
      "line-chart-options"
    );
    var lineChartLabels = $("#lineChart_Numbers_of_Access").data(
      "line-chart-labels"
    );

    var lineChart = new Chart(lineChartCanvas, {
      type: "line",
      data: {
        labels: lineChartLabels,
        datasets: [
          {
            label: "Numbers of Access",
            data: lineChartData,
            borderColor: "#5D0E41",
            borderWidth: 2,
          },
        ],
      },
      options: lineChartOptions,
    });
  }

  var canvasData = $("#MultiLine_Main_Language").data("chart-data");

  if ($("#MultiLine_Main_Language").length) {
    var multiLineCanvas = $("#MultiLine_Main_Language").get(0).getContext("2d");
    var lineChart = new Chart(multiLineCanvas, {
      type: "line",
      data: canvasData,
      options: options, // Chú ý: options cần phải được định nghĩa ở nơi khác
    });
  }
});
