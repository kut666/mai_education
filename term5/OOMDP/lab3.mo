within ;
package MyProject
  model Model1
    import SI = Modelica.SIunits;
    SI.Voltage v,    v1,    v2,    v3,    v4,    v5;
    SI.Current i,    i1,    i2,    i3,    i4,    i5;
    Modelica.Electrical.Analog.Sources.SineVoltage E(V=220, freqHz=50)
      annotation (Placement(transformation(
          extent={{-10,-10},{10,10}},
          rotation=-90,
          origin={-72,0})));
    Modelica.Electrical.Analog.Basic.Ground ground
      annotation (Placement(transformation(extent={{-82,-80},{-62,-60}})));
    Modelica.Electrical.Analog.Basic.Capacitor C(C=1) annotation (Placement(
          transformation(
          extent={{-10,-10},{10,10}},
          rotation=-90,
          origin={76,0})));
    Modelica.Electrical.Analog.Basic.Inductor L(L=1)
      annotation (Placement(transformation(extent={{18,64},{38,84}})));
    Modelica.Electrical.Analog.Basic.Resistor R3(R=1)
      annotation (Placement(transformation(extent={{-54,50},{-34,70}})));
    Modelica.Electrical.Analog.Basic.Resistor R1(R=0.15) 
      annotation (Placement(transformation(extent={{18,34},{38,54}})));
    Modelica.Electrical.Analog.Basic.Resistor R2(R=0.02)
      annotation (Placement(transformation(extent={{10,-64},{-10,-44}})));
  equation
    v2 = v3;
    v = v1 + v2 + v4 + v5;
    i = i1;
    i1 = i2 + i3;
    i2 + i3 = i4;
    i4 = i5;
    v1 = R3.R*i1;
    v2 = R1.R*i2;
    v5 = R2.R*i5;
    L.L*der(i3) = v3;
    C.C*der(v4) = i4;
    v = E.v;
    connect(E.n, ground.p) annotation (Line(
        points={{-72,-10},{-72,-60}},
        color={0,0,255},
        smooth=Smooth.None));
    connect(R2.n, E.n) annotation (Line(
        points={{-10,-54},{-72,-54},{-72,-10}},
        color={0,0,255},
        smooth=Smooth.None));
    connect(R2.p, C.n) annotation (Line(
        points={{10,-54},{76,-54},{76,-10}},
        color={0,0,255},
        smooth=Smooth.None));
    connect(C.p, R1.n) annotation (Line(
        points={{76,10},{76,60},{60,60},{60,44},{38,44}},
        color={0,0,255},
        smooth=Smooth.None));
    connect(C.p, L.n) annotation (Line(
        points={{76,10},{76,60},{60,60},{60,74},{38,74}},
        color={0,0,255},
        smooth=Smooth.None));
    connect(R1.p, R3.n) annotation (Line(
        points={{18,44},{-20,44},{-20,60},{-34,60}},
        color={0,0,255},
        smooth=Smooth.None));
    connect(L.p, R3.n) annotation (Line(
        points={{18,74},{-20,74},{-20,60},{-34,60}},
        color={0,0,255},
        smooth=Smooth.None));
    connect(R3.p, E.p) annotation (Line(
        points={{-54,60},{-72,60},{-72,10}},
        color={0,0,255},
        smooth=Smooth.None));
    annotation (Diagram(coordinateSystem(preserveAspectRatio=false, extent={{-100,
              -100},{100,100}}), graphics));
  end Model1;

  class Resistor
    import SI = Modelica.SIunits;
    
    parameter SI.Resistance R(start = 1) "Resistance at temperature T_ref";
    parameter Modelica.SIunits.Current i_0 = 1;
    extends Modelica.Electrical.Analog.Interfaces.OnePort;
    SI.Resistance R_actual "Actual resistance = R*(1 + alpha*(T_heatPort - T_ref))";
  
  equation
    if (abs(i) <= 3) then
      R_actual = R * i*i*i/(i_0*i_0*i_0);
    else
      if (i > 3) then
        R_actual = R*3*3*3;
      else  
        R_actual = R*3*3*3;
      end if;
    end if;
    v = R_actual * i;
    LossPower = v * i;
    annotation(
      Documentation(info = "<html>
  <p>The linear resistor connects the branch voltage <em>v</em> with the branch current <em>i</em> by <em>i*R = v</em>. The Resistance <em>R</em> is allowed to be positive, zero, or negative.</p>
  </html>", revisions = "<html>
  <ul>
  <li><em> August 07, 2009   </em>
       by Anton Haumer<br> temperature dependency of resistance added<br>
       </li>
  <li><em> March 11, 2009   </em>
       by Christoph Clauss<br> conditional heat port added<br>
       </li>
  <li><em> 1998   </em>
       by Christoph Clauss<br> initially implemented<br>
       </li>
  </ul>
  </html>"),
      Icon(coordinateSystem(preserveAspectRatio = true, extent = {{-100, -100}, {100, 100}}), graphics = {Rectangle(extent = {{-70, 30}, {70, -30}}, lineColor = {0, 0, 255}, fillColor = {255, 255, 255}, fillPattern = FillPattern.Solid), Line(points = {{-90, 0}, {-70, 0}}, color = {0, 0, 255}), Line(points = {{70, 0}, {90, 0}}, color = {0, 0, 255}), Text(extent = {{-150, -40}, {150, -80}}, textString = "R=%R"), Line(visible = useHeatPort, points = {{0, -100}, {0, -30}}, color = {127, 0, 0}, pattern = LinePattern.Dot), Text(extent = {{-150, 90}, {150, 50}}, textString = "%name", lineColor = {0, 0, 255})}));
  end Resistor;
  annotation (uses(Modelica(version="3.2")));
end MyProject;
