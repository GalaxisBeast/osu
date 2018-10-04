// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Graphics;
using osu.Game.Rulesets.Edit;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Rulesets.Osu.Objects.Drawables;
using osu.Game.Rulesets.Osu.Objects.Drawables.Pieces;
using OpenTK;

namespace osu.Game.Rulesets.Osu.Edit.Masks
{
    public partial class SliderSelectionMask
    {
        private class CircleSelectionMask : SelectionMask
        {
            public CircleSelectionMask(DrawableHitCircle sliderHead, DrawableSlider slider)
                : this(sliderHead, Vector2.Zero, slider)
            {
            }

            public CircleSelectionMask(DrawableSliderTail sliderTail, DrawableSlider slider)
                : this(sliderTail, ((Slider)slider.HitObject).Curve.PositionAt(1), slider)
            {
            }

            private readonly DrawableOsuHitObject hitObject;

            private CircleSelectionMask(DrawableOsuHitObject hitObject, Vector2 position, DrawableSlider slider)
                : base(hitObject)
            {
                this.hitObject = hitObject;

                Origin = Anchor.Centre;

                Position = position;
                Size = slider.HeadCircle.Size;
                Scale = slider.HeadCircle.Scale;

                AddInternal(new RingPiece());

                Select();
            }

            [BackgroundDependencyLoader]
            private void load(OsuColour colours)
            {
                Colour = colours.Yellow;
            }

            protected override void Update()
            {
                base.Update();

                RelativeAnchorPosition = hitObject.RelativeAnchorPosition;
            }

            // Todo: This is temporary, since the slider circle masks don't do anything special yet. In the future they will handle input.
            public override bool HandlePositionalInput => false;
        }
    }
}
