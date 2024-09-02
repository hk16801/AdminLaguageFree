(function ($) {
  "use strict";
  $(function () {
    // Remove pro banner on close
    document.addEventListener("DOMContentLoaded", function () {
      // Bạn có thể thêm các đoạn mã JavaScript khác ở đây nếu cần

      // Thêm bộ lắng nghe sự kiện click cho nút đóng banner
      var bannerCloseButton = document.querySelector("#bannerClose");
      if (bannerCloseButton) {
        bannerCloseButton.addEventListener("click", function () {
          var proBanner = document.querySelector("#proBanner");
          if (proBanner) {
            proBanner.classList.add("d-none");
          }
        });
      }
    });
    if ($("#circleProgress6").length) {
      var progressValue = parseFloat($("#circleProgress6").data("progress")); // Lấy giá trị tiến độ từ data-attributes

      var bar = new ProgressBar.Circle(circleProgress6, {
        color: "#001737",
        strokeWidth: 10,
        trailWidth: 10,
        easing: "easeInOut",
        duration: 1400,
        text: {
          autoStyleContainer: false,
        },
        from: {
          color: "#aaa",
          width: 10,
        },
        to: {
          color: "#2617c9",
          width: 10,
        },
        step: function (state, circle) {
          circle.path.setAttribute("stroke", state.color);
          circle.path.setAttribute("stroke-width", state.width);

          var value =
            '<p class="text-center mb-0">Score</p>' +
            Math.round(circle.value() * 100) +
            "%";
          if (value === 0) {
            circle.setText("");
          } else {
            circle.setText(value);
          }
        },
      });

      bar.text.style.fontSize = "1.875rem";
      bar.text.style.fontWeight = "700";
      bar.animate(progressValue); // Sử dụng giá trị tiến độ từ data-attributes
    }
    if ($("#circleProgress7").length) {
      var bar = new ProgressBar.Circle(circleProgress7, {
        color: "#9c9fa6",
        // This has to be the same size as the maximum width to
        // prevent clipping
        strokeWidth: 10,
        trailWidth: 10,
        easing: "easeInOut",
        trailColor: "#1f2130",
        duration: 1400,
        text: {
          autoStyleContainer: false,
        },
        from: {
          color: "#aaa",
          width: 10,
        },
        to: {
          color: "#2617c9",
          width: 10,
        },
        // Set default step function for all animate calls
        step: function (state, circle) {
          circle.path.setAttribute("stroke", state.color);
          circle.path.setAttribute("stroke-width", state.width);

          var value =
            '<p class="text-center mb-0">Score</p>' +
            Math.round(circle.value() * 100) +
            "%";
          if (value === 0) {
            circle.setText("");
          } else {
            circle.setText(value);
          }
        },
      });

      bar.text.style.fontSize = "1.875rem";
      bar.text.style.fontWeight = "700";
      bar.animate(0.75); // Number from 0.0 to 1.0
    }

    if ($("#eventChart").length) {
      var lineChartCanvas = $("#eventChart").get(0).getContext("2d");

      // Lấy dữ liệu từ data-attributes
      var labels = $("#eventChart").data("labels").split(",");
      var criticalData = $("#eventChart")
        .data("critical-data")
        .split(",")
        .map(Number);
      var errorData = $("#eventChart")
        .data("error-data")
        .split(",")
        .map(Number);
      var warningData = $("#eventChart")
        .data("warning-data")
        .split(",")
        .map(Number);

      var eventData = {
        labels: labels,
        datasets: [
          {
            label: "Critical",
            data: criticalData,
            backgroundColor: "rgba(255, 131, 0, 0.1)",
            borderColor: "rgba(255, 131, 0)",
            borderWidth: 1,
            fill: true,
          },
          {
            label: "Error",
            data: errorData,
            backgroundColor: "rgba(242, 18, 38, 0.1)",
            borderColor: "rgba(242, 18, 38)",
            borderWidth: 1,
            fill: true,
          },
          {
            label: "Warning",
            data: warningData,
            backgroundColor: "rgba(23, 23, 201, 0.1)",
            borderColor: "rgba(23, 23, 201)",
            borderWidth: 1,
            fill: true,
          },
        ],
      };

      var eventOptions = {
        scales: {
          yAxes: [
            {
              display: false,
            },
          ],
          xAxes: [
            {
              display: false,
              position: "bottom",
              gridLines: {
                drawBorder: false,
                display: true,
              },
              ticks: {
                display: false,
                beginAtZero: true,
                stepSize: 10,
              },
            },
          ],
        },
        legend: {
          display: false,
          labels: {
            boxWidth: 0,
          },
        },
        elements: {
          point: {
            radius: 0,
          },
          line: {
            tension: 0.1,
          },
        },
        tooltips: {
          backgroundColor: "rgba(2, 171, 254, 1)",
        },
      };

      var saleschart = new Chart(lineChartCanvas, {
        type: "line",
        data: eventData,
        options: eventOptions,
      });
    }
    if ($("#salesanalyticChart").length) {
      // Lấy context của canvas
      var lineChartCanvas = $("#salesanalyticChart").get(0).getContext("2d");

      // Lấy dữ liệu từ các data-attributes của canvas
      var labels = $("#salesanalyticChart").data("labels").split(",");
      var criticalData = $("#salesanalyticChart")
        .data("critical-data")
        .split(",")
        .map(Number);
      var warningData = $("#salesanalyticChart")
        .data("warning-data")
        .split(",")
        .map(Number);
      var errorData = $("#salesanalyticChart")
        .data("error-data")
        .split(",")
        .map(Number);

      // Tạo đối tượng dữ liệu cho biểu đồ
      var salesanalyticData = {
        labels: labels,
        datasets: [
          {
            label: "Critical",
            data: criticalData,
            borderColor: "#3022cb",
            borderWidth: 3,
            fill: false,
          },
          {
            label: "Warning",
            data: warningData,
            borderColor: "#ff8300",
            borderWidth: 3,
            fill: false,
          },
          {
            label: "Error",
            data: errorData,
            borderColor: "#f2125e",
            borderWidth: 3,
            fill: false,
          },
        ],
      };

      // Cài đặt các tùy chọn cho biểu đồ
      var salesanalyticOptions = {
        scales: {
          yAxes: [
            {
              display: true,
              gridLines: {
                drawBorder: false,
                display: true,
              },
              ticks: {
                display: false,
                beginAtZero: false,
                stepSize: 5,
              },
            },
          ],
          xAxes: [
            {
              display: true,
              position: "bottom",
              gridLines: {
                drawBorder: false,
                display: false,
              },
              ticks: {
                display: true,
                beginAtZero: true,
                stepSize: 5,
              },
            },
          ],
        },
        legend: {
          display: false,
          labels: {
            boxWidth: 0,
          },
        },
        elements: {
          point: {
            radius: 0,
          },
          line: {
            tension: 0.4,
          },
        },
        tooltips: {
          backgroundColor: "rgba(2, 171, 254, 1)",
        },
      };

      // Tạo biểu đồ sử dụng dữ liệu và tùy chọn đã thiết lập
      var saleschart = new Chart(lineChartCanvas, {
        type: "line",
        data: salesanalyticData,
        options: salesanalyticOptions,
      });
    }

    if ($("#salesTopChart").length) {
      // Lấy context của canvas
      var graphGradient = document
        .getElementById("salesTopChart")
        .getContext("2d");

      // Tạo gradient cho nền của biểu đồ
      var saleGradientBg = graphGradient.createLinearGradient(25, 0, 25, 110);
      saleGradientBg.addColorStop(0, "rgba(242,18,94, 1)");
      saleGradientBg.addColorStop(1, "rgba(255, 255, 255, 1)");

      // Lấy dữ liệu từ các data-attribute của canvas
      var labels = $("#salesTopChart").data("labels").split(",");
      var values = $("#salesTopChart").data("values").split(",").map(Number);

      // Tạo đối tượng dữ liệu cho biểu đồ
      var salesTopData = {
        labels: labels,
        datasets: [
          {
            label: "# of Votes",
            data: values,
            backgroundColor: saleGradientBg,
            borderColor: ["rgba(242,18,94)"],
            borderWidth: 2,
            fill: true,
          },
        ],
      };

      // Cài đặt các tùy chọn cho biểu đồ
      var salesTopOptions = {
        scales: {
          yAxes: [
            {
              display: true,
              gridLines: {
                display: true,
                drawBorder: true,
              },
              ticks: {
                display: false,
                beginAtZero: true,
              },
            },
          ],
          xAxes: [
            {
              display: true,
              gridLines: {
                display: true,
                drawBorder: false,
              },
              ticks: {
                beginAtZero: true,
                maxTicksLimit: 4,
                maxRotation: 360,
                minRotation: 360,
                padding: 10,
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
          line: {
            tension: 0.1,
          },
        },
        tooltips: {
          backgroundColor: "rgba(31, 59, 179, 1)",
        },
      };

      // Tạo biểu đồ sử dụng dữ liệu và tùy chọn đã thiết lập
      var salesTop = new Chart(graphGradient, {
        type: "line",
        data: salesTopData,
        options: salesTopOptions,
      });
    }
    if ($("#ecommerceAnalytic").length) {
      // Lấy context của canvas
      var lineChartCanvas = $("#ecommerceAnalytic").get(0).getContext("2d");

      // Lấy dữ liệu từ các data-attributes của canvas
      var labels = $("#ecommerceAnalytic").data("labels").split(",");
      var criticalValues = $("#ecommerceAnalytic")
        .data("critical-values")
        .split(",")
        .map(Number);
      var warningValues = $("#ecommerceAnalytic")
        .data("warning-values")
        .split(",")
        .map(Number);

      // Tạo đối tượng dữ liệu cho biểu đồ
      var eCommerceAnalyticData = {
        labels: labels,
        datasets: [
          {
            label: "Critical",
            data: criticalValues,
            borderColor: ["#392ccd"],
            borderWidth: 3,
            fill: true,
            backgroundColor: "rgba(242, 250, 247, .6)",
          },
          {
            label: "Warning",
            data: warningValues,
            borderColor: ["#17c964"],
            borderWidth: 3,
            fill: true,
            backgroundColor: "rgba(200, 200, 200,.5)",
          },
        ],
      };

      // Cài đặt các tùy chọn cho biểu đồ
      var eCommerceAnalyticOptions = {
        scales: {
          yAxes: [
            {
              display: true,
              gridLines: {
                drawBorder: false,
                display: true,
              },
              ticks: {
                display: false,
                beginAtZero: false,
                stepSize: 5,
              },
            },
          ],
          xAxes: [
            {
              display: false,
              position: "bottom",
              gridLines: {
                drawBorder: false,
                display: false,
              },
              ticks: {
                display: true,
                beginAtZero: true,
                stepSize: 5,
              },
            },
          ],
        },
        legend: {
          display: false,
          labels: {
            boxWidth: 0,
          },
        },
        elements: {
          point: {
            radius: 0,
          },
          line: {
            tension: 0.4,
          },
        },
        tooltips: {
          backgroundColor: "rgba(2, 171, 254, 1)",
        },
      };

      // Tạo biểu đồ sử dụng dữ liệu và tùy chọn đã thiết lập
      var saleschart = new Chart(lineChartCanvas, {
        type: "line",
        data: eCommerceAnalyticData,
        options: eCommerceAnalyticOptions,
      });
    }
    var eCommerceAnalyticDarkData = {
      labels: [
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16",
        "17",
        "18",
        "19",
        "20",
        "21",
        "22",
        "23",
        "24",
        "25",
        "26",
        "27",
        "28",
        "29",
        "30",
        "31",
        "32",
        "33",
        "34",
        "35",
        "36",
        "37",
        "38",
        "39",
        "40",
        "41",
        "42",
        "43",
        "44",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16",
        "17",
        "18",
        "19",
        "20",
        "21",
        "22",
        "23",
        "24",
        "25",
        "26",
        "27",
        "28",
        "29",
        "30",
        "31",
        "32",
        "33",
        "34",
        "35",
        "36",
        "37",
        "38",
        "39",
        "40",
        "41",
      ],
      datasets: [
        {
          label: "Critical",
          data: [
            56, 56, 55, 59, 59, 59, 57, 56, 57, 54, 56, 58, 57, 59, 58, 59, 57,
            55, 56, 54, 52, 52, 50, 50, 50, 52, 48, 49, 50, 52, 53, 52, 55, 54,
            53, 56, 55, 56, 55, 54, 55, 57, 58, 56, 55, 56, 57, 58, 59, 58, 57,
            55, 53, 52, 55, 57, 55, 54, 52, 55, 57, 56, 57, 58, 59, 58, 59, 57,
            56, 55, 57, 58, 59, 60, 62, 60, 59, 58, 57, 56, 57, 56, 58, 59,
          ],
          borderColor: ["#392ccd"],
          borderWidth: 3,
          fill: true,
          backgroundColor: "rgba(0, 0, 0, .2)",
        },
        {
          label: "Warning",
          data: [
            32, 32, 35, 39, 39, 39, 37, 36, 37, 34, 36, 38, 37, 39, 38, 39, 37,
            35, 36, 34, 30, 28, 31, 29, 27, 24, 23, 26, 25, 27, 28, 29, 32, 30,
            33, 31, 35, 34, 32, 35, 37, 35, 36, 34, 30, 28, 28, 28, 32, 29, 33,
            35, 33, 32, 35, 37, 35, 34, 32, 35, 37, 36, 37, 38, 39, 38, 39, 37,
            36, 35, 37, 38, 39, 36, 37, 35, 39, 38, 37, 36, 37, 36, 38, 39,
          ],
          borderColor: ["#17c964"],
          borderWidth: 3,
          fill: true,
          backgroundColor: "rgba(0, 0, 0,.3)",
        },
      ],
    };
    var eCommerceAnalyticDarkOptions = {
      scales: {
        yAxes: [
          {
            display: true,
            gridLines: {
              drawBorder: false,
              display: true,
            },
            ticks: {
              display: false,
              beginAtZero: false,
              stepSize: 5,
            },
          },
        ],
        xAxes: [
          {
            display: false,
            position: "bottom",
            gridLines: {
              drawBorder: false,
              display: false,
            },
            ticks: {
              display: true,
              beginAtZero: true,
              stepSize: 5,
            },
          },
        ],
      },
      legend: {
        display: false,
        labels: {
          boxWidth: 0,
        },
      },
      elements: {
        point: {
          radius: 0,
        },
        line: {
          tension: 0.4,
        },
      },
      tooltips: {
        backgroundColor: "rgba(2, 171, 254, 1)",
      },
    };
    if ($("#ecommerceAnalyticDark").length) {
      var lineChartCanvas = $("#ecommerceAnalyticDark").get(0).getContext("2d");
      var saleschart = new Chart(lineChartCanvas, {
        type: "line",
        data: eCommerceAnalyticDarkData,
        options: eCommerceAnalyticDarkOptions,
      });
    }
    // =====DoughnutPie=======
    var Data_Top_Source_Language = {
      datasets: [
        {
          backgroundColor: [
            "#FF204E",
            "#ffca1d",
            "#5356FF",
            "#711DB0",
            "#65B741",
            "#B4B4B8",
          ],
          borderColor: [
            "#eeeeee",
            "#eeeeee",
            "#eeeeee",
            "#eeeeee",
            "#eeeeee",
            "#eeeeee",
          ],
        },
      ],
    };
    var Data_Top_Target_Language = {
      datasets: [
        {
          backgroundColor: [
            "#FF204E",
            "#ffca1d",
            "#5356FF",
            "#711DB0",
            "#65B741",
            "#B4B4B8",
          ],
          borderColor: [
            "#eeeeee",
            "#eeeeee",
            "#eeeeee",
            "#eeeeee",
            "#eeeeee",
            "#eeeeee",
          ],
        },
      ],
    };
    var doughnutPieOptions = {
      responsive: true,
      animation: {
        animateScale: true,
        animateRotate: true,
      },
    };
    //doughnutPieChart_Top_Source_Language
    if ($("#doughnutPieChart_Top_Source_Language").length) {
      var doughnutChartCanvas = $("#doughnutPieChart_Top_Source_Language")
        .get(0)
        .getContext("2d");
      var chartData = JSON.parse(
        $("#doughnutPieChart_Top_Source_Language").attr("data-chart-data")
      );
      chartData.datasets[0].backgroundColor =
        Data_Top_Source_Language.datasets[0].backgroundColor;
      chartData.datasets[0].borderColor =
        Data_Top_Source_Language.datasets[0].borderColor;
      var doughnutChart = new Chart(doughnutChartCanvas, {
        type: "doughnut",
        data: chartData,
        options: doughnutPieOptions,
      });
    }
    //doughnutPieChart_Top_Target_Language
    if ($("#doughnutPieChart_Top_Target_Language").length) {
      var doughnutChartCanvas = $("#doughnutPieChart_Top_Target_Language")
        .get(0)
        .getContext("2d");
      var chartData = JSON.parse(
        $("#doughnutPieChart_Top_Target_Language").attr("data-chart-data")
      );
      chartData.datasets[0].backgroundColor =
        Data_Top_Target_Language.datasets[0].backgroundColor;
      chartData.datasets[0].borderColor =
        Data_Top_Target_Language.datasets[0].borderColor;
      var doughnutChart = new Chart(doughnutChartCanvas, {
        type: "doughnut",
        data: chartData,
        options: doughnutPieOptions,
      });
    }
    //Most Functions Usage
    var option_Most_Function = {
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
    var canvasData = $("#MultiLine_Most_Function").data("chart-data");
    if ($("#MultiLine_Most_Function").length) {
      var multiLineCanvas = $("#MultiLine_Most_Function")
        .get(0)
        .getContext("2d");
      var lineChart = new Chart(multiLineCanvas, {
        type: "line",
        data: canvasData,
        options: option_Most_Function,
      });
    }
    //MutibarChart Template
    // var canvas = document.getElementById("MultiBarChart_User_Activity");
    // var chartData = JSON.parse(canvas.getAttribute("data-chart-data"));
    // var ctx = canvas.getContext("2d");
    // var myChart = new Chart(ctx, {
    //   type: "bar",
    //   data: chartData,
    //   options: {
    //     responsive: true,
    //   },
    // });
    //User_Activity_Analytics
    var options_User_Activity = {
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
    var User_Activity_Color = {
      datasets: [
        {
          backgroundColor: [
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
          ],
          borderColor: [
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
            "#5356FF",
          ],
          borderWidth: 1,
          fill: false,
        },
      ],
    };
    if ($("#barChart_User_Activity").length) {
      var barChartCanvas = $("#barChart_User_Activity").get(0).getContext("2d");
      var ChartData = JSON.parse(
        $("#barChart_User_Activity").attr("data-user-activity")
      ); // No need to parse JSON here

      ChartData.datasets[0].backgroundColor =
        User_Activity_Color.datasets[0].backgroundColor;
      ChartData.datasets[0].borderColor =
        User_Activity_Color.datasets[0].borderColor;
      var barChart = new Chart(barChartCanvas, {
        type: "bar",
        data: ChartData,
        options: options_User_Activity,
      });
    }
    //User_Gender_Analysis
    var options_Gender_Analysis = {
      scales: {
        yAxes: [
          {
            ticks: {
              beginAtZero: true,
              max: 100,
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
    var Gender_User_Color = {
      datasets: [
        {
          backgroundColor: ["#5356FF", "#f71848"],
          borderColor: ["#eeeee", "#eeeee"],
          borderWidth: 1,
          fill: false,
        },
      ],
    };
    if ($("#barChart_Gender_Analysis").length) {
      var barChartCanvas = $("#barChart_Gender_Analysis")
        .get(0)
        .getContext("2d");
      var ChartData = JSON.parse(
        $("#barChart_Gender_Analysis").attr("data-gender-user")
      ); // No need to parse JSON here

      ChartData.datasets[0].backgroundColor =
        Gender_User_Color.datasets[0].backgroundColor;
      ChartData.datasets[0].borderColor =
        Gender_User_Color.datasets[0].borderColor;
      var barChart = new Chart(barChartCanvas, {
        type: "bar",
        data: ChartData,
        options: options_Gender_Analysis,
      });
    }
    //User_Age_Analysis
    var options_Age_Analysis = {
      scales: {
        yAxes: [
          {
            ticks: {
              beginAtZero: true,
              max: 100,
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
    var Age_User_Color = {
      datasets: [
        {
          backgroundColor: [
            "#FF204E",
            "#ffca1d",
            "#5356FF",
            "#711DB0",
            "#65B741",
          ],
          borderColor: ["#eeeee", "#eeeee", "#eeeee", "#eeeee", "#eeeee"],
          borderWidth: 1,
          fill: false,
        },
      ],
    };
    if ($("#barChart_Age_Analysis").length) {
      var barChartCanvas = $("#barChart_Age_Analysis").get(0).getContext("2d");
      var ChartData = JSON.parse(
        $("#barChart_Age_Analysis").attr("data-age-user")
      );
      ChartData.datasets[0].backgroundColor =
        Age_User_Color.datasets[0].backgroundColor;
      ChartData.datasets[0].borderColor =
        Age_User_Color.datasets[0].borderColor;
      var barChart = new Chart(barChartCanvas, {
        type: "bar",
        data: ChartData,
        options: options_Age_Analysis,
      });
    }
    //Star Average
    function displayStars(averageRate) {
      const infoTongElement = document.querySelector("#Average_Star_Icon");
      infoTongElement.innerHTML = ""; // Clear existing stars

      // Round down the integer part of the average rate
      const fullStars = Math.floor(averageRate);

      // Check for decimal part
      const hasHalfStar = averageRate % 1 !== 0;

      // Generate star icons
      for (let i = 0; i < fullStars; i++) {
        const starIcon = document.createElement("i");
        starIcon.classList.add("star-icon", "fa-solid", "fa-star");
        infoTongElement.appendChild(starIcon);
      }

      if (hasHalfStar) {
        const halfStarIcon = document.createElement("i");
        halfStarIcon.classList.add(
          "star-icon",
          "fa-solid",
          "fa-star-half-stroke"
        );
        infoTongElement.appendChild(halfStarIcon);
      }
    }

    // Example usage:
    const averageRate = parseFloat(
      document.getElementById("AverageRateIds").innerText
    );
    displayStars(averageRate);
  });

  $(document).ready(function () {
    $(".navbar-toggler").click(function () {
      $(".navbar-brand").toggleClass("logo-expanded");
      $(".logo-new").toggle();
    });
  });
})(jQuery);

//set từng thời gian cho mỗi trang
$(document).ready(function () {
  function time() {
    var today = new Date();
    var weekday = new Array(7);
    weekday[0] = "Sunday";
    weekday[1] = "Monday";
    weekday[2] = "Tuesday";
    weekday[3] = "Wednesday";
    weekday[4] = "Thursday";
    weekday[5] = "Friday";
    weekday[6] = "Saturday";
    var day = weekday[today.getDay()];
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    var ampm = h >= 12 ? "PM" : "AM"; // Kiểm tra xem giờ hiện tại là AM hay PM
    h = h % 12;
    h = h ? h : 12; // Đổi giờ 0 thành 12
    m = checkTime(m);
    s = checkTime(s);
    nowTime = h + ":" + m + ":" + s + " " + ampm; // Thêm AM/PM vào thời gian
    if (dd < 10) {
      dd = "0" + dd;
    }
    if (mm < 10) {
      mm = "0" + mm;
    }
    today = day + ", " + dd + "/" + mm + "/" + yyyy;
    tmp = '<span class="date"> ' + today + " - " + nowTime + "</span>";
    document.getElementById("clock").innerHTML = tmp;
    clocktime = setTimeout(time, 1000);

    function checkTime(i) {
      if (i < 10) {
        i = "0" + i;
      }
      return i;
    }
  }

  time();
});
